using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Model of a journal entry.
/// </summary>
public class JournalEntryModel : SnelStartResource
{
    public DateTimeOffset? ModifiedOn { get; set; }

    public DateTimeOffset? Datum { get; set; }

    public bool? Markering { get; set; }

    public string? Boekstuk { get; set; }

    public bool? GewijzigdDoorAccountant { get; set; }

    public string? Omschrijving { get; set; }

    public IReadOnlyList<MemorialBookingLineModel>? MemoriaalBoekingsRegels { get; set; }

    public IReadOnlyList<MemorialRelatedBookingLineModel>? InkoopboekingBoekingsRegels { get; set; }

    public IReadOnlyList<MemorialRelatedBookingLineModel>? VerkoopboekingBoekingsRegels { get; set; }

    public SnelStartReference? Dagboek { get; set; }
}
