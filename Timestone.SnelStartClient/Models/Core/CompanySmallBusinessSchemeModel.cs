using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Model for the small business scheme.
/// </summary>
public class CompanySmallBusinessSchemeModel : SnelStartModel
{
    public bool? IsKleineOndernemersRegelingActief { get; set; }

    public decimal? MaximaalBedragVolledigeVerrekening { get; set; }

    public decimal? MaximaalBedragKleineOndernemersRegeling { get; set; }
}
