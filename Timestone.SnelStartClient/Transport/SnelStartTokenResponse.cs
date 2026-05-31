using Newtonsoft.Json;

namespace Timestone.SnelStartClient.Transport;

/// <summary>
/// Response from the SnelStart token endpoint.
/// </summary>
internal sealed class SnelStartTokenResponse
{
    /// <summary>
    /// The bearer token issued by the token endpoint.
    /// </summary>
    [JsonProperty("access_token")]
    public string? AccessToken { get; set; }

    /// <summary>
    /// The number of seconds for which the token is valid.
    /// </summary>
    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }
}
