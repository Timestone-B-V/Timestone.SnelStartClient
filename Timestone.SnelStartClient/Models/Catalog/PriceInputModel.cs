using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Represents how a catalog price is entered.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PriceInputModel
{
    Bedrag,
    StaffelBedrag,
    Korting,
    StaffelKorting,
}
