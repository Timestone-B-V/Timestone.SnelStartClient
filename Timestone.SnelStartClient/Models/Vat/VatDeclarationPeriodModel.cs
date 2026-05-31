using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Represents the declaration period of a VAT declaration.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum VatDeclarationPeriodModel
{
    Onbekend,
    Maand,
    Kwartaal,
    Jaar,
}
