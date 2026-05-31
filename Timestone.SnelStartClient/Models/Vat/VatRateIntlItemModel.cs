using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// International VAT rate for a country.
/// </summary>
public class VatRateIntlItemModel : SnelStartModel
{
    public string? RateCode { get; set; }

    public decimal? Rate { get; set; }

    public DateTimeOffset? ValidFrom { get; set; }
}
