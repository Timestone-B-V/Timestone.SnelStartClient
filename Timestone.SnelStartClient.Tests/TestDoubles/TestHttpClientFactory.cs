using System.Net.Http;

namespace Timestone.SnelStartClient.Tests.TestDoubles;

internal sealed class TestHttpClientFactory : IHttpClientFactory
{
    private readonly HttpClient _httpClient;

    internal TestHttpClientFactory(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public HttpClient CreateClient(string name)
        => _httpClient;
}
