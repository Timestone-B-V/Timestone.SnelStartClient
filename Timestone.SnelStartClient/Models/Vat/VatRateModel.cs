using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Model of a VAT rate.
/// </summary>
public class VatRateModel : SnelStartResource
{
    public BtwSoortModel? BtwSoort { get; set; }

    public decimal? BtwPercentage { get; set; }

    public DateTimeOffset? DatumVanaf { get; set; }

    public DateTimeOffset? DatumTotEnMet { get; set; }
}
