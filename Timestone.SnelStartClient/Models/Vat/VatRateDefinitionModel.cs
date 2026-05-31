using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Model of a VAT rate definition.
/// </summary>
public class VatRateDefinitionModel : SnelStartResource
{
    public string? RateCode { get; set; }

    public string? ShortName { get; set; }

    public string? Name { get; set; }
}
