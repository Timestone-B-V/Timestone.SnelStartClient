using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Model of a sales entry.
/// </summary>
public class SaleEntryModel : SnelStartResource
{
    public DateTimeOffset? ModifiedOn { get; set; }

    public string? Boekstuk { get; set; }

    public bool? GewijzigdDoorAccountant { get; set; }

    public bool? Markering { get; set; }

    public DateTimeOffset? Factuurdatum { get; set; }

    public string? Factuurnummer { get; set; }

    public SnelStartReference? Klant { get; set; }

    public string? Omschrijving { get; set; }

    public decimal? Factuurbedrag { get; set; }

    public int? Betalingstermijn { get; set; }

    public OneOffDirectDebitAuthorizationModel? EenmaligeIncassoMachtiging { get; set; }

    public SnelStartReference? DoorlopendeIncassoMachtiging { get; set; }

    public IReadOnlyList<SaleBookingLineModel>? Boekingsregels { get; set; }

    public IReadOnlyList<SaleVatLineModel>? Btw { get; set; }

    public IReadOnlyList<DocumentModel>? Documents { get; set; }
}
