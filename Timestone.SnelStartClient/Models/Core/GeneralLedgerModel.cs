using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Vat;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents an available general ledger.
/// </summary>
public class GeneralLedgerModel : SnelStartResource
{
    public DateTimeOffset? ModifiedOn { get; set; }

    public string? Omschrijving { get; set; }

    public bool? KostenplaatsVerplicht { get; set; }

    public GeneralLedgerAccountTypeModel? RekeningCode { get; set; }

    public bool? Nonactief { get; set; }

    public int? Nummer { get; set; }

    public GeneralLedgerFunctionModel? Grootboekfunctie { get; set; }

    public string? GrootboekRubriek { get; set; }

    public IReadOnlyList<RgsCodeModel>? RgsCode { get; set; }

    public IReadOnlyList<BtwSoortModel>? BtwSoort { get; set; }

    public string? VatRateCode { get; set; }
}
