using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for general ledger mutations.
/// </summary>
internal sealed class GeneralLedgerMutationsRepository : SnelStartRepositoryBase, IGeneralLedgerMutationsRepository
{
    /// <summary>
    /// Initializes a new repository for general ledger mutations.
    /// </summary>
    public GeneralLedgerMutationsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<GeneralLedgerMutationModel>> IGeneralLedgerMutationsRepository.ListAsync(GeneralLedgerMutationQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<GeneralLedgerMutationModel>("grootboekmutaties", queryOptions, cancellationToken);

    Task<GeneralLedgerMutationModel?> IGeneralLedgerMutationsRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<GeneralLedgerMutationModel>($"grootboekmutaties/{id}", cancellationToken: cancellationToken);
}