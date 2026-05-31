using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Timestone.SnelStartClient.Configuration;

namespace Timestone.SnelStartClient.Transport;

/// <summary>
/// Requests access tokens and caches them until shortly before expiration.
/// </summary>
internal sealed class SnelStartAccessTokenProvider : ISnelStartAccessTokenProvider
{
    private static readonly JsonSerializerSettings SerializerSettings = new()
    {
        NullValueHandling = NullValueHandling.Ignore,
        DateParseHandling = DateParseHandling.DateTimeOffset
    };

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptions<SnelStartClientOptions> _options;
    private readonly ISnelStartClientKeyProvider _clientKeyProvider;
    private readonly ConcurrentDictionary<string, SemaphoreSlim> _refreshLocks = new(StringComparer.Ordinal);
    private readonly ConcurrentDictionary<string, SnelStartAccessToken> _cachedTokens = new(StringComparer.Ordinal);

    internal SnelStartAccessTokenProvider(IHttpClientFactory httpClientFactory, IOptions<SnelStartClientOptions> options, ISnelStartClientKeyProvider clientKeyProvider)
    {
        _httpClientFactory = httpClientFactory;
        _options = options;
        _clientKeyProvider = clientKeyProvider;
    }

    async ValueTask<string?> ISnelStartAccessTokenProvider.GetAccessTokenAsync(CancellationToken cancellationToken)
    {
        var clientKey = await _clientKeyProvider.GetClientKeyAsync(cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(clientKey))
        {
            return null;
        }

        if (_cachedTokens.TryGetValue(clientKey, out var cachedToken) && IsUsable(cachedToken))
        {
            return cachedToken.AccessToken;
        }

        var refreshLock = _refreshLocks.GetOrAdd(clientKey, static _ => new SemaphoreSlim(1, 1));
        await refreshLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_cachedTokens.TryGetValue(clientKey, out cachedToken) && IsUsable(cachedToken))
            {
                return cachedToken.AccessToken;
            }

            var refreshedToken = await RequestTokenAsync(clientKey, cancellationToken).ConfigureAwait(false);
            _cachedTokens[clientKey] = refreshedToken;
            return refreshedToken.AccessToken;
        }
        finally
        {
            refreshLock.Release();
        }
    }

    private bool IsUsable(SnelStartAccessToken? token)
        => token is not null && token.ExpiresAtUtc > DateTimeOffset.UtcNow.AddSeconds(_options.Value.TokenExpirationBufferSeconds);

    private async Task<SnelStartAccessToken> RequestTokenAsync(string clientKey, CancellationToken cancellationToken)
    {
        var options = _options.Value;
        var request = new HttpRequestMessage(HttpMethod.Post, options.AuthUrl)
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "clientkey",
                ["clientkey"] = clientKey
            })
        };

        if (!string.IsNullOrWhiteSpace(options.SnelStartSubscriptionKey))
        {
            request.Headers.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", options.SnelStartSubscriptionKey);
        }

        var client = _httpClientFactory.CreateClient(options.SnelStartHttpClientName);
        using var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new SnelStartApiException(response.StatusCode, request.RequestUri!, content);
        }

        var tokenResponse = JsonConvert.DeserializeObject<SnelStartTokenResponse>(content, SerializerSettings)
            ?? throw new InvalidOperationException("The SnelStart token response could not be read.");

        if (string.IsNullOrWhiteSpace(tokenResponse.AccessToken))
        {
            throw new InvalidOperationException("The SnelStart token response does not contain an access token.");
        }

        return new SnelStartAccessToken
        {
            AccessToken = tokenResponse.AccessToken,
            ExpiresAtUtc = DateTimeOffset.UtcNow.AddSeconds(tokenResponse.ExpiresIn)
        };
    }
}
