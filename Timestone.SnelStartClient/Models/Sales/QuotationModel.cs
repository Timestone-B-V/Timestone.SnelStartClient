using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Model of a quotation.
/// </summary>
public class QuotationModel : SnelStartResource
{
    public SnelStartReference? Relatie { get; set; }

    public SaleOrderProcessStatusModel? ProcesStatus { get; set; }

    public int? Nummer { get; set; }

    public DateTimeOffset? ModifiedOn { get; set; }

    public DateTimeOffset? Datum { get; set; }

    public int? Krediettermijn { get; set; }

    public string? Omschrijving { get; set; }

    public string? Betalingskenmerk { get; set; }

    public SnelStartReference? Incassomachtiging { get; set; }

    public AddressModel? Afleveradres { get; set; }

    public AddressModel? Factuuradres { get; set; }

    public SaleOrderVatEntryModeModel? VerkooporderBtwIngaveModel { get; set; }

    public SnelStartReference? Kostenplaats { get; set; }

    public IReadOnlyList<SaleOrderLineModel>? Regels { get; set; }

    public string? Memo { get; set; }

    public string? Orderreferentie { get; set; }

    public decimal? Factuurkorting { get; set; }

    public SnelStartReference? Verkoopfactuur { get; set; }

    public decimal? TotaalExclusiefBtw { get; set; }

    public decimal? TotaalInclusiefBtw { get; set; }

    public bool? IsOfferte { get; set; }
}
