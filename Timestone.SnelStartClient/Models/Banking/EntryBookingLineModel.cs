using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Banking;

/// <summary>
/// Booking line for a linked entry.
/// </summary>
public class EntryBookingLineModel : SnelStartModel
{
    /// <summary>
    /// Reference to the linked entry.
    /// </summary>
    public SnelStartReference? BoekingId { get; set; }

    /// <summary>
    /// Description of the line.
    /// </summary>
    public string? Omschrijving { get; set; }

    /// <summary>
    /// Debit amount.
    /// </summary>
    public decimal? Debet { get; set; }

    /// <summary>
    /// Credit amount.
    /// </summary>
    public decimal? Credit { get; set; }
}
