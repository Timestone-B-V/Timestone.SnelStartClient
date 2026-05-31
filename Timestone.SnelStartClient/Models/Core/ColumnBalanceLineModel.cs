using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Line of a column balance report.
/// </summary>
public class ColumnBalanceLineModel : SnelStartModel
{
    public SnelStartReference? GrootboekIdentifier { get; set; }

    public string? GrootboekOmschrijving { get; set; }

    public int? GrootboekNummer { get; set; }

    public decimal? VerliesEnWinstDebet { get; set; }

    public decimal? VerliesEnWinstCredit { get; set; }

    public decimal? BalansDebet { get; set; }

    public decimal? BalansCredit { get; set; }

    public IReadOnlyList<RgsCodeModel>? RgsCode { get; set; }
}
