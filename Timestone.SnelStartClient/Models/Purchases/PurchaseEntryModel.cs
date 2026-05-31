using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Purchases;

/// <summary>
/// Model of a purchase entry.
/// </summary>
public class PurchaseEntryModel : SnelStartResource
{
    public DateTimeOffset? ModifiedOn { get; set; }

    public string? Boekstuk { get; set; }

    public bool? GewijzigdDoorAccountant { get; set; }

    public bool? Markering { get; set; }

    public DateTimeOffset? Factuurdatum { get; set; }

    public string? Factuurnummer { get; set; }

    public SnelStartReference? Leverancier { get; set; }

    public string? Omschrijving { get; set; }

    public decimal? Factuurbedrag { get; set; }

    public IReadOnlyList<PurchaseBookingLineModel>? Boekingsregels { get; set; }

    public IReadOnlyList<PurchaseVatLineModel>? Btw { get; set; }

    public IReadOnlyList<DocumentModel>? Documents { get; set; }
}
