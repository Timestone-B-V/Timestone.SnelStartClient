using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Catalog;

/// <summary>
/// Repository for action prices.
/// </summary>
public interface IActionPricesRepository
{
    /// <summary>
    /// Gets all available action prices from an administration.
    /// </summary>
    Task<IReadOnlyList<ActionPriceModel>> ListAsync(ActionPriceQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);
}
