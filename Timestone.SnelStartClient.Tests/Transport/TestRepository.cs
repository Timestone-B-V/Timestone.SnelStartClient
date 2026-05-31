using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Tests.Transport;

internal sealed class TestRepository : SnelStartRepositoryBase
{
    internal TestRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    internal Task<TModel?> InvokeGetAsync<TModel>(string path, object? query = null, CancellationToken cancellationToken = default)
        => GetAsync<TModel>(path, query, cancellationToken);

    internal Task<IReadOnlyList<TModel>> InvokeGetListAsync<TModel>(string path, object? query = null, CancellationToken cancellationToken = default)
        => GetListAsync<TModel>(path, query, cancellationToken);

    internal Task<TModel?> InvokePostAsync<TModel>(string path, object? body, object? query = null, CancellationToken cancellationToken = default)
        => PostAsync<TModel>(path, body, query, cancellationToken);

    internal Task<TModel?> InvokePutAsync<TModel>(string path, object? body, object? query = null, CancellationToken cancellationToken = default)
        => PutAsync<TModel>(path, body, query, cancellationToken);

    internal Task<bool> InvokeDeleteAsync(string path, CancellationToken cancellationToken = default)
        => DeleteAsync(path, cancellationToken);
}
