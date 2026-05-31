using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Banking;

/// <summary>
/// General ledger booking line within a bank entry.
/// </summary>
public class LedgerBookingLineModel : SnelStartModel
{
    /// <summary>
    /// Description of the line.
    /// </summary>
    public string? Omschrijving { get; set; }

    /// <summary>
    /// General ledger reference.
    /// </summary>
    public SnelStartReference? Grootboek { get; set; }

    /// <summary>
    /// Cost centre reference.
    /// </summary>
    public SnelStartReference? Kostenplaats { get; set; }

    /// <summary>
    /// Debit amount.
    /// </summary>
    public decimal? Debet { get; set; }

    /// <summary>
    /// Credit amount.
    /// </summary>
    public decimal? Credit { get; set; }

    /// <summary>
    /// VAT type.
    /// </summary>
    public string? BtwSoort { get; set; }
}
