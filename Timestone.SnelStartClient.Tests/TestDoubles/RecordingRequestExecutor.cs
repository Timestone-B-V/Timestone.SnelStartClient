using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Tests.TestDoubles;

internal sealed class RecordingRequestExecutor : ISnelStartRequestExecutor
{
    internal HttpMethod? LastMethod { get; private set; }

    internal string? LastPath { get; private set; }

    internal object? LastBody { get; private set; }

    internal object? LastQuery { get; private set; }

    internal Func<HttpMethod, string, object?, object?, CancellationToken, Task<object?>>? SendAsyncResultFactory { get; set; }

    internal Func<HttpMethod, string, object?, object?, CancellationToken, Task>? SendAsyncFactory { get; set; }

    public async Task<TResponse?> SendAsync<TResponse>(HttpMethod method, string path, object? body = null, object? query = null, CancellationToken cancellationToken = default)
    {
        LastMethod = method;
        LastPath = path;
        LastBody = body;
        LastQuery = query;

        if (SendAsyncResultFactory is null)
        {
            return default;
        }

        var result = await SendAsyncResultFactory(method, path, body, query, cancellationToken).ConfigureAwait(false);
        return (TResponse?)result;
    }

    public async Task SendAsync(HttpMethod method, string path, object? body = null, object? query = null, CancellationToken cancellationToken = default)
    {
        LastMethod = method;
        LastPath = path;
        LastBody = body;
        LastQuery = query;

        if (SendAsyncFactory is not null)
        {
            await SendAsyncFactory(method, path, body, query, cancellationToken).ConfigureAwait(false);
        }
    }
}
