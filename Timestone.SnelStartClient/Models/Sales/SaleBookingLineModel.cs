using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Models.Vat;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Booking line within a sales entry.
/// </summary>
public class SaleBookingLineModel : SnelStartModel
{
    public string? Omschrijving { get; set; }

    public SnelStartReference? Grootboek { get; set; }

    public SnelStartReference? Kostenplaats { get; set; }

    public decimal? Bedrag { get; set; }

    public BtwSoortModel? BtwSoort { get; set; }
}
