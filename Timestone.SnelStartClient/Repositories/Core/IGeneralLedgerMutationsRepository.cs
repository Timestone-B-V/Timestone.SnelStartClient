using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for general ledger mutations.
/// </summary>
public interface IGeneralLedgerMutationsRepository
{
    /// <summary>
    /// Gets all available general ledger mutations.
    /// </summary>
    Task<IReadOnlyList<GeneralLedgerMutationModel>> ListAsync(GeneralLedgerMutationQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a general ledger mutation by its identifier.
    /// </summary>
    Task<GeneralLedgerMutationModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
