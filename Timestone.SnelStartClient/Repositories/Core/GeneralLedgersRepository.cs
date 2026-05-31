using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for general ledgers.
/// </summary>
internal sealed class GeneralLedgersRepository : SnelStartRepositoryBase, IGeneralLedgersRepository
{
    /// <summary>
    /// Initializes a new repository for general ledgers.
    /// </summary>
    public GeneralLedgersRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<GeneralLedgerModel>> IGeneralLedgersRepository.ListAsync(GeneralLedgerQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<GeneralLedgerModel>("grootboeken", queryOptions, cancellationToken);

    Task<GeneralLedgerModel?> IGeneralLedgersRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<GeneralLedgerModel>($"grootboeken/{id}", cancellationToken: cancellationToken);

    Task<GeneralLedgerModel?> IGeneralLedgersRepository.CreateAsync(GeneralLedgerModel generalLedger, CancellationToken cancellationToken)
        => PostAsync<GeneralLedgerModel>("grootboeken", generalLedger, cancellationToken: cancellationToken);
}