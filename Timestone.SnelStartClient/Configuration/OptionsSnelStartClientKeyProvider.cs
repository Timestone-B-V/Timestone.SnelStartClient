using Microsoft.Extensions.Options;

namespace Timestone.SnelStartClient.Configuration;

/// <summary>
/// Provides the configured fallback client key from <see cref="SnelStartClientOptions"/>.
/// </summary>
public sealed class OptionsSnelStartClientKeyProvider : ISnelStartClientKeyProvider
{
    private readonly IOptions<SnelStartClientOptions> _options;

    /// <summary>
    /// Initializes a new provider that returns the fallback client key from the configured options.
    /// </summary>
    /// <param name="options">The configured SnelStart client options.</param>
    public OptionsSnelStartClientKeyProvider(IOptions<SnelStartClientOptions> options)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options;
    }

    /// <summary>
    /// Gets the fallback client key from the configured options.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>The configured fallback client key, or <see langword="null"/> when no fallback key has been configured.</returns>
    public ValueTask<string?> GetClientKeyAsync(CancellationToken cancellationToken = default)
        => ValueTask.FromResult<string?>(_options.Value.ClientKey);
}
