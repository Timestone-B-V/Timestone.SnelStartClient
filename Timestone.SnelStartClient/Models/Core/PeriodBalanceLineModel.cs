using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Line of a period balance report.
/// </summary>
public class PeriodBalanceLineModel : SnelStartModel
{
    public SnelStartReference? GrootboekIdentifier { get; set; }

    public string? GrootboekOmschrijving { get; set; }

    public int? GrootboekNummer { get; set; }

    public decimal? Debet { get; set; }

    public decimal? Credit { get; set; }

    public decimal? StartSaldoPeriode { get; set; }

    public decimal? EindSaldoPeriode { get; set; }

    public decimal? StartSaldoBoekjaar { get; set; }

    public IReadOnlyList<RgsCodeModel>? RgsCode { get; set; }
}
