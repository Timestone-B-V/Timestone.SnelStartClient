using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Reference line to a linked entry in a journal entry.
/// </summary>
public class MemorialRelatedBookingLineModel : SnelStartModel
{
    public SnelStartReference? BoekingId { get; set; }

    public string? Omschrijving { get; set; }

    public decimal? Bedrag { get; set; }
}
