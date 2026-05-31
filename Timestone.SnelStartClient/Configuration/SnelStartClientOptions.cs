namespace Timestone.SnelStartClient.Configuration;

/// <summary>
/// Configuration for the SnelStart client.
/// </summary>
public sealed class SnelStartClientOptions
{
    /// <summary>
    /// The default name of the <see cref="HttpClient"/> retrieved through <see cref="System.Net.Http.IHttpClientFactory"/>.
    /// </summary>
    public const string DefaultHttpClientName = "SnelStartHttpClientName";

    /// <summary>
    /// The base URL of the SnelStart B2B API.
    /// </summary>
    public string BaseUrl { get; set; } = "https://b2bapi.snelstart.nl/v2/";

    /// <summary>
    /// The URL of the SnelStart token endpoint.
    /// </summary>
    public string AuthUrl { get; set; } = "https://auth.snelstart.nl/b2b/token";

    /// <summary>
    /// The fallback client key used to request an access token when no runtime <see cref="ISnelStartClientKeyProvider"/> is registered.
    /// </summary>
    public string ClientKey { get; set; } = string.Empty;

    /// <summary>
    /// The subscription key sent as the <c>Ocp-Apim-Subscription-Key</c> header.
    /// </summary>
    public string SnelStartSubscriptionKey { get; set; } = string.Empty;

    /// <summary>
    /// The name of the <see cref="HttpClient"/> retrieved through <see cref="System.Net.Http.IHttpClientFactory"/>.
    /// </summary>
    public string SnelStartHttpClientName { get; set; } = DefaultHttpClientName;

    /// <summary>
    /// The number of seconds before expiration at which a token is refreshed.
    /// </summary>
    public int TokenExpirationBufferSeconds { get; set; } = 60;
}
