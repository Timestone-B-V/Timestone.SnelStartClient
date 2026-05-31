using System.Net;
using System.Text;
using Microsoft.Extensions.Options;
using Timestone.SnelStartClient.Configuration;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Tests.TestDoubles;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Tests.Transport;

public sealed class SnelStartRequestExecutorTests
{
    [Fact]
    public async Task SendAsync_WhenRelativePathAndQueryAreProvided_BuildsExpectedRequestAndDeserializesResponse()
    {
        Uri? capturedRequestUri = null;
        string? capturedAuthorization = null;
        string? capturedSubscriptionKey = null;
        var relationId = Guid.NewGuid();
        var handler = new RecordingHttpMessageHandler((request, _) =>
        {
            capturedRequestUri = request.RequestUri;
            capturedAuthorization = request.Headers.Authorization?.ToString();
            request.Headers.TryGetValues("Ocp-Apim-Subscription-Key", out var values);
            capturedSubscriptionKey = values?.SingleOrDefault();

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{" + "\"waarde\":\"ok\"}" )
            });
        });
        var httpClientFactory = new TestHttpClientFactory(new HttpClient(handler));
        var accessTokenProvider = new TestAccessTokenProvider(_ => ValueTask.FromResult<string?>("access-token"));
        var executor = new SnelStartRequestExecutor(
            httpClientFactory,
            accessTokenProvider,
            Options.Create(new SnelStartClientOptions
            {
                BaseUrl = "https://api.example.test/",
                SnelStartSubscriptionKey = "subscription-key"
            }));

        var result = await executor.SendAsync<Dictionary<string, string>>(
            HttpMethod.Get,
            "artikelen",
            query: new ArticleQueryOptions
            {
                RelationId = relationId,
                Amount = 3
            });

        Assert.NotNull(result);
        Assert.Equal("ok", result["waarde"]);
        Assert.NotNull(capturedRequestUri);
        Assert.Equal("https://api.example.test/artikelen", capturedRequestUri!.GetLeftPart(UriPartial.Path));
        Assert.Equal(relationId.ToString(), ParseQuery(capturedRequestUri)["relatieId"]);
        Assert.Equal("3", ParseQuery(capturedRequestUri)["aantal"]);
        Assert.Equal("Bearer access-token", capturedAuthorization);
        Assert.Equal("subscription-key", capturedSubscriptionKey);
    }

    [Fact]
    public async Task SendAsync_WhenBodyIsProvided_SerializesBodyAsJson()
    {
        string? capturedBody = null;
        var handler = new RecordingHttpMessageHandler(async (request, _) =>
        {
            capturedBody = request.Content is null ? null : await request.Content.ReadAsStringAsync();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{" + "\"id\":\"1\"}")
            };
        });
        var executor = CreateExecutor(handler);

        await executor.SendAsync<Dictionary<string, string>>(HttpMethod.Post, "artikelen", body: new { Omschrijving = "Test" });

        Assert.Equal("{\"Omschrijving\":\"Test\"}", capturedBody);
    }

    [Fact]
    public async Task SendAsync_WhenResponseContentIsEmpty_ReturnsDefault()
    {
        var handler = new RecordingHttpMessageHandler((_, _) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(string.Empty)
        }));
        var executor = CreateExecutor(handler);

        var result = await executor.SendAsync<Dictionary<string, string>>(HttpMethod.Get, "artikelen");

        Assert.Null(result);
    }

    [Fact]
    public async Task SendAsync_WhenApiReturnsError_ThrowsSnelStartApiException()
    {
        var handler = new RecordingHttpMessageHandler((request, _) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            RequestMessage = request,
            Content = new StringContent("[{\"errorCode\":\"BOE-0021\",\"message\":\"Het factuurnummer bestaat al\",\"details\":null}]", Encoding.UTF8, "application/json")
        }));
        var executor = CreateExecutor(handler);

        var action = async () => await executor.SendAsync<Dictionary<string, string>>(HttpMethod.Get, "artikelen");

        var exception = await Assert.ThrowsAsync<SnelStartApiException>(action);
        Assert.Equal(HttpStatusCode.BadRequest, exception.StatusCode);
        Assert.Equal("[{\"errorCode\":\"BOE-0021\",\"message\":\"Het factuurnummer bestaat al\",\"details\":null}]", exception.ResponseBody);
        Assert.Equal("BOE-0021: Het factuurnummer bestaat al", exception.ApiMessage);
        Assert.Contains("Het factuurnummer bestaat al", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public async Task SendAsync_WhenAccessTokenIsMissing_DoesNotSetAuthorizationHeader()
    {
        string? capturedAuthorization = null;
        var handler = new RecordingHttpMessageHandler((request, _) =>
        {
            capturedAuthorization = request.Headers.Authorization?.ToString();
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{" + "\"waarde\":\"ok\"}")
            });
        });
        var httpClientFactory = new TestHttpClientFactory(new HttpClient(handler));
        var accessTokenProvider = new TestAccessTokenProvider(_ => ValueTask.FromResult<string?>(null));
        var executor = new SnelStartRequestExecutor(
            httpClientFactory,
            accessTokenProvider,
            Options.Create(new SnelStartClientOptions
            {
                BaseUrl = "https://api.example.test/"
            }));

        await executor.SendAsync<Dictionary<string, string>>(HttpMethod.Get, "artikelen");

        Assert.Null(capturedAuthorization);
    }

    [Fact]
    public async Task SendAsync_WhenConfiguredBaseUrlHasNoTrailingSlash_AppendsPathCorrectly()
    {
        Uri? capturedRequestUri = null;
        var handler = new RecordingHttpMessageHandler((request, _) =>
        {
            capturedRequestUri = request.RequestUri;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{" + "\"waarde\":\"ok\"}")
            });
        });
        var executor = new SnelStartRequestExecutor(
            new TestHttpClientFactory(new HttpClient(handler)),
            new TestAccessTokenProvider(_ => ValueTask.FromResult<string?>(null)),
            Options.Create(new SnelStartClientOptions
            {
                BaseUrl = "https://api.example.test"
            }));

        var result = await executor.SendAsync<Dictionary<string, string>>(HttpMethod.Get, "artikelen");

        Assert.NotNull(result);
        Assert.Equal("https://api.example.test/artikelen", capturedRequestUri?.ToString());
    }

    [Fact]
    public async Task SendAsync_WhenAbsolutePathIsProvided_UsesAbsolutePathWithoutConfiguredBaseUrl()
    {
        Uri? capturedRequestUri = null;
        var handler = new RecordingHttpMessageHandler((request, _) =>
        {
            capturedRequestUri = request.RequestUri;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{" + "\"waarde\":\"ok\"}")
            });
        });
        var executor = new SnelStartRequestExecutor(
            new TestHttpClientFactory(new HttpClient(handler)),
            new TestAccessTokenProvider(_ => ValueTask.FromResult<string?>(null)),
            Options.Create(new SnelStartClientOptions
            {
                BaseUrl = string.Empty
            }));

        var result = await executor.SendAsync<Dictionary<string, string>>(HttpMethod.Get, "https://other.example.test/artikelen?bestaand=1");

        Assert.NotNull(result);
        Assert.Equal("https://other.example.test/artikelen?bestaand=1", capturedRequestUri?.ToString());
    }

    [Fact]
    public async Task SendAsync_WhenRelativePathIsProvidedWithoutBaseUrl_ThrowsInvalidOperationException()
    {
        var executor = new SnelStartRequestExecutor(
            new TestHttpClientFactory(new HttpClient(new RecordingHttpMessageHandler((_, _) => throw new InvalidOperationException("The request must not be sent.")))),
            new TestAccessTokenProvider(_ => ValueTask.FromResult<string?>(null)),
            Options.Create(new SnelStartClientOptions
            {
                BaseUrl = string.Empty
            }));

        var action = async () => await executor.SendAsync<Dictionary<string, string>>(HttpMethod.Get, "artikelen");

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(action);
        Assert.Equal("No BaseUrl has been configured for the SnelStart client.", exception.Message);
    }

    [Fact]
    public async Task SendAsync_WithoutGenericResponse_WhenCalled_CompletesSuccessfully()
    {
        var handler = new RecordingHttpMessageHandler((_, _) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.NoContent)
        {
            Content = new StringContent(string.Empty)
        }));
        var executor = CreateExecutor(handler);

        await executor.SendAsync(HttpMethod.Delete, "artikelen/1");

        Assert.Equal(1, handler.CallCount);
    }

    private static SnelStartRequestExecutor CreateExecutor(RecordingHttpMessageHandler handler)
        => new(
            new TestHttpClientFactory(new HttpClient(handler)),
            new TestAccessTokenProvider(_ => ValueTask.FromResult<string?>("access-token")),
            Options.Create(new SnelStartClientOptions
            {
                BaseUrl = "https://api.example.test/"
            }));

    private static IReadOnlyDictionary<string, string> ParseQuery(Uri uri)
        => uri.Query.TrimStart('?')
            .Split('&', StringSplitOptions.RemoveEmptyEntries)
            .Select(part => part.Split('=', 2))
            .ToDictionary(
                part => Uri.UnescapeDataString(part[0]),
                part => Uri.UnescapeDataString(part[1]),
                StringComparer.Ordinal);
}
