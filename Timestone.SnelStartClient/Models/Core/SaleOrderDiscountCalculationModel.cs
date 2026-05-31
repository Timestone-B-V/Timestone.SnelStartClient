using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents how sales order line discount is calculated.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SaleOrderDiscountCalculationModel
{
    /// <summary>
    /// Calculate discount over the line amount.
    /// </summary>
    BerekenenOverRegelBedrag,

    /// <summary>
    /// Calculate discount over the unit price.
    /// </summary>
    BerekenenOverStukprijs,
}
