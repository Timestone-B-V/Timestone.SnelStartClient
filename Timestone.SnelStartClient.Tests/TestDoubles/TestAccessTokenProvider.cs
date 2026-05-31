using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Tests.TestDoubles;

internal sealed class TestAccessTokenProvider : ISnelStartAccessTokenProvider
{
    private readonly Func<CancellationToken, ValueTask<string?>> _accessTokenFactory;

    internal TestAccessTokenProvider(Func<CancellationToken, ValueTask<string?>> accessTokenFactory)
    {
        _accessTokenFactory = accessTokenFactory;
    }

    public ValueTask<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => _accessTokenFactory(cancellationToken);
}
