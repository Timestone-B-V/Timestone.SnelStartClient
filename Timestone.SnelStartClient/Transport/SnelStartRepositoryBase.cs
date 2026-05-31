namespace Timestone.SnelStartClient.Transport;

/// <summary>
/// Base implementation for repositories that communicate with the SnelStart API.
/// </summary>
public abstract class SnelStartRepositoryBase
{
    /// <summary>
    /// Initializes a new repository base.
    /// </summary>
    /// <param name="requestExecutor">The request executor.</param>
    protected SnelStartRepositoryBase(ISnelStartRequestExecutor requestExecutor)
    {
        RequestExecutor = requestExecutor;
    }

    /// <summary>
    /// The request executor.
    /// </summary>
    protected ISnelStartRequestExecutor RequestExecutor { get; }

    /// <summary>
    /// Executes a GET request and returns a single model.
    /// </summary>
    protected Task<TModel?> GetAsync<TModel>(string path, object? query = null, CancellationToken cancellationToken = default)
        => RequestExecutor.SendAsync<TModel>(HttpMethod.Get, path, query: query, cancellationToken: cancellationToken);

    /// <summary>
    /// Executes a GET request and returns a list.
    /// </summary>
    protected async Task<IReadOnlyList<TModel>> GetListAsync<TModel>(string path, object? query = null, CancellationToken cancellationToken = default)
    {
        var models = await RequestExecutor.SendAsync<List<TModel>>(HttpMethod.Get, path, query: query, cancellationToken: cancellationToken).ConfigureAwait(false);
        return models ?? [];
    }

    /// <summary>
    /// Executes a POST request.
    /// </summary>
    protected Task<TModel?> PostAsync<TModel>(string path, object? body, object? query = null, CancellationToken cancellationToken = default)
        => RequestExecutor.SendAsync<TModel>(HttpMethod.Post, path, body, query, cancellationToken);

    /// <summary>
    /// Executes a PUT request.
    /// </summary>
    protected Task<TModel?> PutAsync<TModel>(string path, object? body, object? query = null, CancellationToken cancellationToken = default)
        => RequestExecutor.SendAsync<TModel>(HttpMethod.Put, path, body, query, cancellationToken);

    /// <summary>
    /// Executes a DELETE request.
    /// </summary>
    protected async Task<bool> DeleteAsync(string path, CancellationToken cancellationToken = default)
    {
        await RequestExecutor.SendAsync(HttpMethod.Delete, path, cancellationToken: cancellationToken).ConfigureAwait(false);
        return true;
    }
}
