using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents an available country.
/// </summary>
public class CountryModel : SnelStartResource
{
    public string? Naam { get; set; }

    public string? LandcodeISO { get; set; }

    public string? Landcode { get; set; }
}
