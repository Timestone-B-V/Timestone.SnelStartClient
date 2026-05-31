using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the VAT or ICP declaration period configured for company settings.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum CompanyVatPeriodTypeModel
{
    /// <summary>
    /// Monthly period.
    /// </summary>
    Maand,

    /// <summary>
    /// Quarterly period.
    /// </summary>
    Kwartaal,

    /// <summary>
    /// Yearly period.
    /// </summary>
    Jaar,
}
