using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Catalog;

/// <summary>
/// Implementation of the repository for action prices.
/// </summary>
internal sealed class ActionPricesRepository : SnelStartRepositoryBase, IActionPricesRepository
{
    /// <summary>
    /// Initializes a new repository for action prices.
    /// </summary>
    public ActionPricesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<ActionPriceModel>> IActionPricesRepository.ListAsync(ActionPriceQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<ActionPriceModel>("actieprijzen", queryOptions, cancellationToken);
}