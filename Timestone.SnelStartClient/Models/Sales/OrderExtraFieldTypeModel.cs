using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Represents the data type of an extra sales order field.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum OrderExtraFieldTypeModel
{
    GeheelGetal,
    Bedrag,
    Datum,
    Tekst,
    Klant,
    Leverancier,
    Artikel,
    Artikelgroep,
    Land,
    Factuur,
    Grootboekrekening,
}
