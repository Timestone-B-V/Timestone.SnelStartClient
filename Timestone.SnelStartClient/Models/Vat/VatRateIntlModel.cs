using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Model of an international VAT rate definition.
/// </summary>
public class VatRateIntlModel : SnelStartResource
{
    public string? CountryCode { get; set; }

    public IReadOnlyList<VatRateIntlItemModel>? VatRates { get; set; }
}
