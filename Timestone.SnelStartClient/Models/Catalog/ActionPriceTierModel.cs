using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Price tier within an action price.
/// </summary>
public class ActionPriceTierModel : SnelStartModel
{
    /// <summary>
    /// The tier threshold.
    /// </summary>
    public decimal? Vanaf { get; set; }

    /// <summary>
    /// The discount.
    /// </summary>
    public decimal? Korting { get; set; }

    /// <summary>
    /// The sales price.
    /// </summary>
    public decimal? Verkoopprijs { get; set; }

    /// <summary>
    /// The base price.
    /// </summary>
    public decimal? Basisprijs { get; set; }
}
