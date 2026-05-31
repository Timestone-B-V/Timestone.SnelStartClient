using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents an available journal.
/// </summary>
public class JournalModel : SnelStartResource
{
    public string? Omschrijving { get; set; }

    public JournalTypeModel? Soort { get; set; }

    public bool? Nonactief { get; set; }

    public int? Nummer { get; set; }
}
