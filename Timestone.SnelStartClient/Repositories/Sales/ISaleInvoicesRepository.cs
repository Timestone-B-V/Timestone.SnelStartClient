using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Repository for sales invoices.
/// </summary>
public interface ISaleInvoicesRepository
{
    /// <summary>
    /// Gets all available sales invoices from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<SaleInvoiceModel>> ListAsync(SaleInvoiceQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a sales invoice by its identifier.
    /// </summary>
    Task<SaleInvoiceModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the UBL of a sales invoice.
    /// </summary>
    Task<SaleInvoiceUblModel?> GetUblAsync(Guid id, CancellationToken cancellationToken = default);
}
