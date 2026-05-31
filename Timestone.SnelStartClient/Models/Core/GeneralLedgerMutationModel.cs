using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents an available general ledger mutation.
/// </summary>
public class GeneralLedgerMutationModel : SnelStartResource
{
    public SnelStartReference? Grootboek { get; set; }

    public SnelStartReference? Kostenplaats { get; set; }

    public DateTimeOffset? Datum { get; set; }

    public DateTimeOffset? ModifiedOn { get; set; }

    public SnelStartReference? Dagboek { get; set; }

    public string? Omschrijving { get; set; }

    public decimal? Debet { get; set; }

    public decimal? Credit { get; set; }

    public decimal? Saldo { get; set; }

    public IReadOnlyList<DocumentModel>? Documents { get; set; }

    public string? Boekstuk { get; set; }

    public string? FactuurNummer { get; set; }

    public SnelStartReference? RelatiePublicIdentifier { get; set; }
}
