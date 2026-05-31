using Timestone.SnelStartClient.Models.Sales;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Typed OData query options for retrieving sales invoices.
/// </summary>
public sealed class SaleInvoiceQueryOptions : ODataQueryOptions<SaleInvoiceModel>;