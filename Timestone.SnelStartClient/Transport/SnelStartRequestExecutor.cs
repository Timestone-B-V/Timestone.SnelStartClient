using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Timestone.SnelStartClient.Configuration;

namespace Timestone.SnelStartClient.Transport;

internal sealed class SnelStartRequestExecutor : ISnelStartRequestExecutor
{
    private static readonly JsonSerializerSettings SerializerSettings = new()
    {
        NullValueHandling = NullValueHandling.Ignore,
        DateParseHandling = DateParseHandling.DateTimeOffset
    };

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ISnelStartAccessTokenProvider _accessTokenProvider;
    private readonly IOptions<SnelStartClientOptions> _options;

    internal SnelStartRequestExecutor(IHttpClientFactory httpClientFactory, ISnelStartAccessTokenProvider accessTokenProvider, IOptions<SnelStartClientOptions> options)
    {
        _httpClientFactory = httpClientFactory;
        _accessTokenProvider = accessTokenProvider;
        _options = options;
    }

    /// <summary>
    /// Sends a request and deserializes the response to the specified type.
    /// </summary>
    public async Task<TResponse?> SendAsync<TResponse>(HttpMethod method, string path, object? body = null, object? query = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(method, path, body, query);
        await ApplyAuthorizationAsync(request, cancellationToken).ConfigureAwait(false);
        using var response = await SendCoreAsync(request, cancellationToken).ConfigureAwait(false);
        var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(content))
        {
            return default;
        }

        return JsonConvert.DeserializeObject<TResponse>(content, SerializerSettings);
    }

    /// <summary>
    /// Sends a request without a response body.
    /// </summary>
    public async Task SendAsync(HttpMethod method, string path, object? body = null, object? query = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(method, path, body, query);
        await ApplyAuthorizationAsync(request, cancellationToken).ConfigureAwait(false);
        using var response = await SendCoreAsync(request, cancellationToken).ConfigureAwait(false);
        _ = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
    }

    private HttpRequestMessage CreateRequest(HttpMethod method, string path, object? body, object? query)
    {
        var requestUri = BuildRequestUri(path, query);
        var request = new HttpRequestMessage(method, requestUri);

        var subscriptionKey = _options.Value.SnelStartSubscriptionKey;
        if (!string.IsNullOrWhiteSpace(subscriptionKey))
        {
            request.Headers.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", subscriptionKey);
        }

        if (body is not null)
        {
            var json = JsonConvert.SerializeObject(body, SerializerSettings);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        }

        return request;
    }

    private async Task ApplyAuthorizationAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization is not null)
        {
            return;
        }

        var accessToken = await _accessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            return;
        }

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    private async Task<HttpResponseMessage> SendCoreAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient(_options.Value.SnelStartHttpClientName);
        var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            return response;
        }

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        response.Dispose();
        throw new SnelStartApiException(response.StatusCode, request.RequestUri!, responseBody);
    }

    private Uri BuildRequestUri(string path, object? query)
    {
        if (Uri.TryCreate(SnelStartQueryStringBuilder.AppendQueryString(path, query), UriKind.Absolute, out var absoluteUri))
        {
            return absoluteUri;
        }

        var configuredBaseUrl = _options.Value.BaseUrl;
        if (string.IsNullOrWhiteSpace(configuredBaseUrl))
        {
            throw new InvalidOperationException("No BaseUrl has been configured for the SnelStart client.");
        }

        var baseUri = configuredBaseUrl.EndsWith("/", StringComparison.Ordinal)
            ? new Uri(configuredBaseUrl, UriKind.Absolute)
            : new Uri($"{configuredBaseUrl}/", UriKind.Absolute);

        return new Uri(baseUri, SnelStartQueryStringBuilder.AppendQueryString(path.TrimStart('/'), query));
    }
}
