using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the document level from which stock is shown for sales orders.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SaleOrderStockLevelModel
{
    /// <summary>
    /// All levels.
    /// </summary>
    Alle,

    /// <summary>
    /// Quotation level.
    /// </summary>
    Offerte,

    /// <summary>
    /// Backorder level.
    /// </summary>
    BackOrder,

    /// <summary>
    /// Confirmation level.
    /// </summary>
    Bevestiging,

    /// <summary>
    /// Work order level.
    /// </summary>
    Werkbon,

    /// <summary>
    /// Packing slip and pickup slip level.
    /// </summary>
    PakbonEnAfhaalbon,

    /// <summary>
    /// Invoice and cash receipt level.
    /// </summary>
    FactuurEnContantbon,
}
