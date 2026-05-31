using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Journal booking line.
/// </summary>
public class MemorialBookingLineModel : SnelStartModel
{
    public string? Omschrijving { get; set; }

    public SnelStartReference? Grootboek { get; set; }

    public SnelStartReference? Kostenplaats { get; set; }

    public decimal? Debet { get; set; }

    public decimal? Credit { get; set; }
}
