using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents an available cost centre.
/// </summary>
public class CostCentreModel : SnelStartResource
{
    public string? Omschrijving { get; set; }

    public bool? Nonactief { get; set; }

    public int? Nummer { get; set; }
}
