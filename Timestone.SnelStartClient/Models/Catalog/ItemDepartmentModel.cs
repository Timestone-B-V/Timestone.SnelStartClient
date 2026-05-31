using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Represents an item department.
/// </summary>
public class ItemDepartmentModel : SnelStartResource
{
    /// <summary>
    /// The item department number.
    /// </summary>
    public int? Nummer { get; set; }

    /// <summary>
    /// The description.
    /// </summary>
    public string? Omschrijving { get; set; }

    /// <summary>
    /// The linked sales general ledger identifier for the Netherlands.
    /// </summary>
    public SnelStartReference? VerkoopGrootboekNederlandIdentifier { get; set; }

    /// <summary>
    /// The Dutch VAT type.
    /// </summary>
    public string? VerkoopNederlandBtwSoort { get; set; }
}
