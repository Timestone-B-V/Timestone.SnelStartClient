namespace Timestone.SnelStartClient.Transport;

/// <summary>
/// Provides a valid access token for the SnelStart API.
/// </summary>
internal interface ISnelStartAccessTokenProvider
{
    /// <summary>
    /// Gets a valid access token, or <see langword="null"/> when automatic token retrieval is not configured.
    /// </summary>
    ValueTask<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}
