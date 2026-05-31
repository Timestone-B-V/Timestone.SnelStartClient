using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Section within a VAT declaration.
/// </summary>
public class VatDeclarationSectionModel : SnelStartModel
{
    public decimal? Btw { get; set; }

    public decimal? Omzet { get; set; }

    public decimal? BtwSchatting { get; set; }

    public decimal? OmzetSchatting { get; set; }
}
