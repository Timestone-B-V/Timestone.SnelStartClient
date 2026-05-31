using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Price agreements for a customer on an article.
/// </summary>
public class ArticleCustomerPriceAgreementModel : SnelStartModel
{
    /// <summary>
    /// The public relation identifier.
    /// </summary>
    public Guid? RelatiePublicIdentifier { get; set; }

    /// <summary>
    /// The relation code.
    /// </summary>
    public int? RelatieCode { get; set; }

    /// <summary>
    /// The relation name.
    /// </summary>
    public string? RelatieNaam { get; set; }

    /// <summary>
    /// The start date.
    /// </summary>
    public DateTimeOffset? Startdatum { get; set; }

    /// <summary>
    /// The end date.
    /// </summary>
    public DateTimeOffset? Einddatum { get; set; }

    /// <summary>
    /// The price input mode.
    /// </summary>
    public PriceInputModel? PrijsIngave { get; set; }

    /// <summary>
    /// The status.
    /// </summary>
    public PriceStatusModel? Status { get; set; }

    /// <summary>
    /// The individual price agreements.
    /// </summary>
    public IReadOnlyList<ArticleCustomerPriceAgreementLineModel>? PrijsAfspraken { get; set; }
}
