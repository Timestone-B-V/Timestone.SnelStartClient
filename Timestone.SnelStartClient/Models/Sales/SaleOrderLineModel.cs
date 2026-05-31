using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Sales order line.
/// </summary>
public class SaleOrderLineModel : SnelStartModel
{
    public SnelStartReference? Artikel { get; set; }

    public string? Omschrijving { get; set; }

    public decimal? Stuksprijs { get; set; }

    public decimal? Aantal { get; set; }

    public decimal? KortingsPercentage { get; set; }

    public decimal? Totaal { get; set; }

    public IReadOnlyList<OrderExtraFieldValueModel>? ExtraRegelVelden { get; set; }
}
