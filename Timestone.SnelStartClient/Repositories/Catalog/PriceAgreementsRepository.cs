using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Catalog;

/// <summary>
/// Implementation of the repository for price agreements.
/// </summary>
internal sealed class PriceAgreementsRepository : SnelStartRepositoryBase, IPriceAgreementsRepository
{
    /// <summary>
    /// Initializes a new repository for price agreements.
    /// </summary>
    public PriceAgreementsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<PriceAgreementModel>> IPriceAgreementsRepository.ListAsync(PriceAgreementQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<PriceAgreementModel>("prijsafspraken", queryOptions, cancellationToken);
}