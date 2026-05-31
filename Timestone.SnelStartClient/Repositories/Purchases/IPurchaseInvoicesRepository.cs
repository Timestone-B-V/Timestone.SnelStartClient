using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Purchases;

/// <summary>
/// Repository for purchase invoices.
/// </summary>
public interface IPurchaseInvoicesRepository
{
    /// <summary>
    /// Gets all available purchase invoices from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<PurchaseInvoiceModel>> ListAsync(PurchaseInvoiceQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);
}
