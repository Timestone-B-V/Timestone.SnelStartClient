using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// VAT line within a sales entry.
/// </summary>
public class SaleVatLineModel : SnelStartModel
{
    /// <summary>
    /// Gets or sets the VAT type to which the VAT amount is booked.
    /// </summary>
    public SaleVatSoortModel? BtwSoort { get; set; }

    /// <summary>
    /// Gets or sets the VAT amount booked for the selected VAT type.
    /// </summary>
    public decimal? BtwBedrag { get; set; }
}
