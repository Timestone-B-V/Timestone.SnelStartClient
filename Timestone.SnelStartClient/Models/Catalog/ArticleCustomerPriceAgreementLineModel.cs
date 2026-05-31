using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Individual price agreement line.
/// </summary>
public class ArticleCustomerPriceAgreementLineModel : SnelStartModel
{
    /// <summary>
    /// The minimum quantity.
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
}
