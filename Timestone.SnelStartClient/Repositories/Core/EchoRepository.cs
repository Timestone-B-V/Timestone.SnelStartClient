using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for echo test calls.
/// </summary>
internal sealed class EchoRepository : SnelStartRepositoryBase, IEchoRepository
{
    /// <summary>
    /// Initializes a new repository for echo test calls.
    /// </summary>
    public EchoRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<EchoResultModel?> IEchoRepository.TestAsync(string input, CancellationToken cancellationToken)
        => GetAsync<EchoResultModel>($"echo/{Uri.EscapeDataString(input)}", cancellationToken: cancellationToken);
}