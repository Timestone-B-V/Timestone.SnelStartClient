using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Represents whether sales order amounts are entered inclusive or exclusive of VAT.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SaleOrderVatEntryModeModel
{
    Inclusief,
    Exclusief,
}
