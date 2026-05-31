using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Banking;

/// <summary>
/// Represents a bank entry identified by its identifier.
/// </summary>
public class BankEntryModel : SnelStartResource
{
    /// <summary>
    /// The modification date.
    /// </summary>
    public DateTimeOffset? ModifiedOn { get; set; }

    /// <summary>
    /// The booking date.
    /// </summary>
    public DateTimeOffset? Datum { get; set; }

    /// <summary>
    /// The marker flag.
    /// </summary>
    public bool? Markering { get; set; }

    /// <summary>
    /// The voucher number.
    /// </summary>
    public string? Boekstuk { get; set; }

    /// <summary>
    /// Indicates whether the bank entry was changed by the accountant.
    /// </summary>
    public bool? GewijzigdDoorAccountant { get; set; }

    /// <summary>
    /// The description.
    /// </summary>
    public string? Omschrijving { get; set; }

    /// <summary>
    /// The general ledger booking lines.
    /// </summary>
    public IReadOnlyList<LedgerBookingLineModel>? GrootboekBoekingsRegels { get; set; }

    /// <summary>
    /// The purchase entry booking lines.
    /// </summary>
    public IReadOnlyList<EntryBookingLineModel>? InkoopboekingBoekingsRegels { get; set; }

    /// <summary>
    /// The sales entry booking lines.
    /// </summary>
    public IReadOnlyList<EntryBookingLineModel>? VerkoopboekingBoekingsRegels { get; set; }

    /// <summary>
    /// The VAT booking lines.
    /// </summary>
    public IReadOnlyList<VatBookingLineModel>? BtwBoekingsregels { get; set; }

    /// <summary>
    /// The amount spent.
    /// </summary>
    public decimal? BedragUitgegeven { get; set; }

    /// <summary>
    /// The amount received.
    /// </summary>
    public decimal? BedragOntvangen { get; set; }

    /// <summary>
    /// The journal.
    /// </summary>
    public SnelStartReference? Dagboek { get; set; }
}
