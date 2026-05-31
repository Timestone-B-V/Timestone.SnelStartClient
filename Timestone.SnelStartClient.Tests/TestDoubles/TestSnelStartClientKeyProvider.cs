using Timestone.SnelStartClient.Configuration;

namespace Timestone.SnelStartClient.Tests.TestDoubles;

internal sealed class TestSnelStartClientKeyProvider : ISnelStartClientKeyProvider
{
    private readonly Queue<string?> _clientKeys;

    internal TestSnelStartClientKeyProvider(params string?[] clientKeys)
        : this(new Queue<string?>(clientKeys))
    {
    }

    internal TestSnelStartClientKeyProvider(Queue<string?> clientKeys)
    {
        _clientKeys = clientKeys;
    }

    public ValueTask<string?> GetClientKeyAsync(CancellationToken cancellationToken = default)
        => ValueTask.FromResult(_clientKeys.Count > 0 ? _clientKeys.Dequeue() : null);
}
