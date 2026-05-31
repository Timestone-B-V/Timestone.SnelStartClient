using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Range for invoicing foreign VAT.
/// </summary>
public class CompanyVatRangeModel : SnelStartModel
{
    public int? From { get; set; }

    public int? To { get; set; }
}
