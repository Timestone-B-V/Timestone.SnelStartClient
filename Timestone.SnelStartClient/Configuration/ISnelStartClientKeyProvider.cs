namespace Timestone.SnelStartClient.Configuration;

/// <summary>
/// Provides the client key that should be used for the next SnelStart token request.
/// </summary>
public interface ISnelStartClientKeyProvider
{
    /// <summary>
    /// Gets the client key that should be used for the current SnelStart API interaction.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>The client key to use for the current interaction, or <see langword="null"/> when no automatic token retrieval should be performed.</returns>
    ValueTask<string?> GetClientKeyAsync(CancellationToken cancellationToken = default);
}
