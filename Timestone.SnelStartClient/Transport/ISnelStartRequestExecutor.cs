namespace Timestone.SnelStartClient.Transport;

/// <summary>
/// Executes HTTP requests to the SnelStart API.
/// </summary>
public interface ISnelStartRequestExecutor
{
    /// <summary>
    /// Sends a request and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">The response type.</typeparam>
    /// <param name="method">The HTTP method.</param>
    /// <param name="path">The relative or absolute path.</param>
    /// <param name="body">The request body.</param>
    /// <param name="query">The query string parameters.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The deserialized response object.</returns>
    Task<TResponse?> SendAsync<TResponse>(HttpMethod method, string path, object? body = null, object? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a request without a response body.
    /// </summary>
    /// <param name="method">The HTTP method.</param>
    /// <param name="path">The relative or absolute path.</param>
    /// <param name="body">The request body.</param>
    /// <param name="query">The query string parameters.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task.</returns>
    Task SendAsync(HttpMethod method, string path, object? body = null, object? query = null, CancellationToken cancellationToken = default);
}
