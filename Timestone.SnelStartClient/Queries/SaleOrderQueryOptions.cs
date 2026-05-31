using Timestone.SnelStartClient.Models.Sales;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Typed OData query options for retrieving sales orders.
/// </summary>
public sealed class SaleOrderQueryOptions : ODataQueryOptions<SaleOrderModel>;