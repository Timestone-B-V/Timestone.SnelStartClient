using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Represents the submission status of a VAT declaration.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum VatDeclarationStatusModel
{
    NietVerzonden,
    Verzonden,
    Geaccepteerd,
    Fout,
    GeaccepteerdEnHerberekend,
    GeaccepteerdExtern,
}
