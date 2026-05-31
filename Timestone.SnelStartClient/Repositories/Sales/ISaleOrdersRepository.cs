using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Repository for sales orders.
/// </summary>
public interface ISaleOrdersRepository
{
    /// <summary>
    /// Gets all available sales orders from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<SaleOrderModel>> ListAsync(SaleOrderQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a sales order by its identifier.
    /// </summary>
    Task<SaleOrderModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new sales order.
    /// </summary>
    Task<SaleOrderModel?> CreateAsync(SaleOrderModel saleOrder, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing sales order.
    /// </summary>
    Task<SaleOrderModel?> UpdateAsync(Guid id, SaleOrderModel saleOrder, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a sales order by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the process status of a sales order.
    /// </summary>
    Task<SaleOrderModel?> UpdateProcessStatusAsync(Guid id, SaleOrderProcessStatusUpdateModel payload, CancellationToken cancellationToken = default);
}
