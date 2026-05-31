using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Represents the status of a catalog price configuration.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PriceStatusModel
{
    Verlopen,
    Gepland,
    Actief,
}
