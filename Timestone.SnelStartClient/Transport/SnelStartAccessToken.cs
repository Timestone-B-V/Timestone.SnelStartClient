namespace Timestone.SnelStartClient.Transport;

/// <summary>
/// Cached access token information.
/// </summary>
internal sealed class SnelStartAccessToken
{
    /// <summary>
    /// The token value that is placed in the Authorization header.
    /// </summary>
    internal required string AccessToken { get; init; }

    /// <summary>
    /// The UTC moment when the token expires.
    /// </summary>
    internal required DateTimeOffset ExpiresAtUtc { get; init; }
}
