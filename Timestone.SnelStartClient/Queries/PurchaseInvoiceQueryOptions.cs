using Timestone.SnelStartClient.Models.Purchases;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Typed OData query options for retrieving purchase invoices.
/// </summary>
public sealed class PurchaseInvoiceQueryOptions : ODataQueryOptions<PurchaseInvoiceModel>;