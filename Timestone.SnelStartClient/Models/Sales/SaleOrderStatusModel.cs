using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Represents the execution status of a sales order.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SaleOrderStatusModel
{
    InBehandeling,
    Uitgevoerd,
    Service,
}
