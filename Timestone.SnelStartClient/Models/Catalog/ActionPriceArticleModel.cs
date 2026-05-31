using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Article within an action price.
/// </summary>
public class ActionPriceArticleModel : SnelStartModel
{
    /// <summary>
    /// The article code.
    /// </summary>
    public string? Artikelcode { get; set; }

    /// <summary>
    /// The article description.
    /// </summary>
    public string? ArtikelOmschrijving { get; set; }

    /// <summary>
    /// The price input mode.
    /// </summary>
    public PriceInputModel? PrijsIngave { get; set; }

    /// <summary>
    /// The price tiers.
    /// </summary>
    public IReadOnlyList<ActionPriceTierModel>? Prijzen { get; set; }
}
