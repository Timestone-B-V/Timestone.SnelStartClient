using System.Net;
using Microsoft.Extensions.Options;
using Timestone.SnelStartClient.Configuration;
using Timestone.SnelStartClient.Tests.TestDoubles;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Tests.Transport;

public sealed class SnelStartAccessTokenProviderTests
{
    [Fact]
    public async Task GetAccessTokenAsync_WhenClientKeyIsMissing_ReturnsNullWithoutCallingTokenEndpoint()
    {
        var handler = new RecordingHttpMessageHandler((_, _) => throw new InvalidOperationException("The token endpoint must not be called."));
        var httpClientFactory = new TestHttpClientFactory(new HttpClient(handler));
        ISnelStartAccessTokenProvider provider = new SnelStartAccessTokenProvider(
            httpClientFactory,
            Options.Create(new SnelStartClientOptions()),
            new TestSnelStartClientKeyProvider());

        var token = await provider.GetAccessTokenAsync();

        Assert.Null(token);
        Assert.Equal(0, handler.CallCount);
    }

    [Fact]
    public async Task GetAccessTokenAsync_WhenCachedTokenIsStillValid_ReusesCachedToken()
    {
        var handler = new RecordingHttpMessageHandler((_, _) => Task.FromResult(CreateJsonResponse("""
            {"access_token":"cached-token","expires_in":3600}
            """)));
        var httpClientFactory = new TestHttpClientFactory(new HttpClient(handler));
        var options = Options.Create(new SnelStartClientOptions
        {
            ClientKey = "client-key"
        });
        ISnelStartAccessTokenProvider provider = new SnelStartAccessTokenProvider(
            httpClientFactory,
            options,
            new OptionsSnelStartClientKeyProvider(options));

        var firstToken = await provider.GetAccessTokenAsync();
        var secondToken = await provider.GetAccessTokenAsync();

        Assert.Equal("cached-token", firstToken);
        Assert.Equal("cached-token", secondToken);
        Assert.Equal(1, handler.CallCount);
    }

    [Fact]
    public async Task GetAccessTokenAsync_WhenCachedTokenIsExpired_RequestsNewTokenAgain()
    {
        var accessTokens = new Queue<string>(["expired-token", "fresh-token"]);
        var handler = new RecordingHttpMessageHandler((_, _) => Task.FromResult(CreateJsonResponse($"{{\"access_token\":\"{accessTokens.Dequeue()}\",\"expires_in\":0}}")));
        var httpClientFactory = new TestHttpClientFactory(new HttpClient(handler));
        var options = Options.Create(new SnelStartClientOptions
        {
            ClientKey = "client-key"
        });
        ISnelStartAccessTokenProvider provider = new SnelStartAccessTokenProvider(
            httpClientFactory,
            options,
            new OptionsSnelStartClientKeyProvider(options));

        var firstToken = await provider.GetAccessTokenAsync();
        var secondToken = await provider.GetAccessTokenAsync();

        Assert.Equal("expired-token", firstToken);
        Assert.Equal("fresh-token", secondToken);
        Assert.Equal(2, handler.CallCount);
    }

    [Fact]
    public async Task GetAccessTokenAsync_WhenTokenResponseDoesNotContainAccessToken_ThrowsInvalidOperationException()
    {
        var handler = new RecordingHttpMessageHandler((_, _) => Task.FromResult(CreateJsonResponse("""
            {"expires_in":3600}
            """)));
        var httpClientFactory = new TestHttpClientFactory(new HttpClient(handler));
        var options = Options.Create(new SnelStartClientOptions
        {
            ClientKey = "client-key"
        });
        ISnelStartAccessTokenProvider provider = new SnelStartAccessTokenProvider(
            httpClientFactory,
            options,
            new OptionsSnelStartClientKeyProvider(options));

        var action = async () => await provider.GetAccessTokenAsync();

        await Assert.ThrowsAsync<InvalidOperationException>(action);
    }

    [Fact]
    public async Task GetAccessTokenAsync_WhenClientKeyChanges_CachesTokensPerClientKey()
    {
        var requestBodies = new List<string>();
        var handler = new RecordingHttpMessageHandler(async (request, cancellationToken) =>
        {
            requestBodies.Add(await request.Content!.ReadAsStringAsync(cancellationToken));
            var body = requestBodies[^1].Contains("clientkey=client-b", StringComparison.Ordinal)
                ? """{"access_token":"token-b","expires_in":3600}"""
                : """{"access_token":"token-a","expires_in":3600}""";

            return CreateJsonResponse(body);
        });

        var httpClientFactory = new TestHttpClientFactory(new HttpClient(handler));
        var provider = new TestSnelStartClientKeyProvider(new Queue<string?>(["client-a", "client-b", "client-a"]));
        ISnelStartAccessTokenProvider accessTokenProvider = new SnelStartAccessTokenProvider(
            httpClientFactory,
            Options.Create(new SnelStartClientOptions()),
            provider);

        var firstToken = await accessTokenProvider.GetAccessTokenAsync();
        var secondToken = await accessTokenProvider.GetAccessTokenAsync();
        var thirdToken = await accessTokenProvider.GetAccessTokenAsync();

        Assert.Equal("token-a", firstToken);
        Assert.Equal("token-b", secondToken);
        Assert.Equal("token-a", thirdToken);
        Assert.Equal(2, handler.CallCount);
        Assert.Contains(requestBodies, body => body.Contains("clientkey=client-a", StringComparison.Ordinal));
        Assert.Contains(requestBodies, body => body.Contains("clientkey=client-b", StringComparison.Ordinal));
    }

    private static HttpResponseMessage CreateJsonResponse(string json)
        => new(HttpStatusCode.OK)
        {
            Content = new StringContent(json)
        };
}
