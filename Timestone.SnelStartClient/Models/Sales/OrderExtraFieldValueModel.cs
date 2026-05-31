using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Value of an extra order field.
/// </summary>
public class OrderExtraFieldValueModel : SnelStartModel
{
    public int? VeldNummer { get; set; }

    public string? Omschrijving { get; set; }

    public string? Waarde { get; set; }
}
