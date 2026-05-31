using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Price agreements per article and customer.
/// </summary>
public class ArticlePriceAgreementModel : SnelStartModel
{
    /// <summary>
    /// The article code.
    /// </summary>
    public string? ArtikelCode { get; set; }

    /// <summary>
    /// The article description.
    /// </summary>
    public string? ArtikelOmschrijving { get; set; }

    /// <summary>
    /// The base price.
    /// </summary>
    public decimal? Basisprijs { get; set; }

    /// <summary>
    /// The customer agreements.
    /// </summary>
    public IReadOnlyList<ArticleCustomerPriceAgreementModel>? KlantAfspraken { get; set; }
}
