using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for echo test calls.
/// </summary>
public interface IEchoRepository
{
    /// <summary>
    /// Returns the provided input through the echo endpoint.
    /// </summary>
    Task<EchoResultModel?> TestAsync(string input, CancellationToken cancellationToken = default);
}
