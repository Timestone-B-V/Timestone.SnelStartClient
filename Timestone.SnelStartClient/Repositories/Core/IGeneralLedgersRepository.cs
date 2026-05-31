using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for general ledgers.
/// </summary>
public interface IGeneralLedgersRepository
{
    /// <summary>
    /// Gets all available general ledgers.
    /// </summary>
    Task<IReadOnlyList<GeneralLedgerModel>> ListAsync(GeneralLedgerQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a general ledger by its identifier.
    /// </summary>
    Task<GeneralLedgerModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new general ledger.
    /// </summary>
    Task<GeneralLedgerModel?> CreateAsync(GeneralLedgerModel generalLedger, CancellationToken cancellationToken = default);
}
