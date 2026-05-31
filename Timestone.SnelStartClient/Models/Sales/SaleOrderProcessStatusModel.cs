using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Represents the document process status of a sales order or quotation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SaleOrderProcessStatusModel
{
    Order,
    Offerte,
    Bevestiging,
    Werkbon,
    Pakbon,
    Afhaalbon,
    Contantbon,
    Factuur,
}
