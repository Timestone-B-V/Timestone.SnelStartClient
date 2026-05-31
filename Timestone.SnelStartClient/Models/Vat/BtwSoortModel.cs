using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Represents a standard VAT type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum BtwSoortModel
{
    Geen,
    Laag,
    Hoog,
    Overig,
}
