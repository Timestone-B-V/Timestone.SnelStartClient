using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Represents the rule by which a price agreement is determined.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PriceAgreementDeterminationTypeModel
{
    NormaleVerkoopprijs,
    ActieprijzenPerArtikel,
    ActieprijzenPerArtikelkortingsgroep,
    AfspraakPerArtikelklant,
    AfspraakPerArtikelPerKlantkortingsgroep,
    AfspraakPerKlantPerArtikelkortingsgroep,
    AfspraakPerArtikelkortingsgroepPerKlantkortingsgroep,
}
