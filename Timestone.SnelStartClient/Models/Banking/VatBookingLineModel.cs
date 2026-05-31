using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Banking;

/// <summary>
/// VAT booking line.
/// </summary>
public class VatBookingLineModel : SnelStartModel
{
    /// <summary>
    /// Debit amount.
    /// </summary>
    public decimal? Debet { get; set; }

    /// <summary>
    /// Credit amount.
    /// </summary>
    public decimal? Credit { get; set; }

    /// <summary>
    /// VAT booking line type.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// VAT rate.
    /// </summary>
    public string? Tarief { get; set; }
}
