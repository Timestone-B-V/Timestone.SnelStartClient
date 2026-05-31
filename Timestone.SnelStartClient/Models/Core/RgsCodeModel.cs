using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// RGS code including its version.
/// </summary>
public class RgsCodeModel : SnelStartModel
{
    public string? Versie { get; set; }

    public string? RgsCode { get; set; }
}
