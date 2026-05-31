using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Purchases;

/// <summary>
/// VAT line within a purchase entry.
/// </summary>
public class PurchaseVatLineModel : SnelStartModel
{
    public PurchaseVatSoortModel? BtwSoort { get; set; }

    public decimal? BtwBedrag { get; set; }
}
