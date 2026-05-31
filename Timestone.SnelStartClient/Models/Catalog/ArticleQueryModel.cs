using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Represents an article by its identifier and the optionally specified relation.
/// </summary>
public class ArticleQueryModel : ArticleModel
{
    /// <summary>
    /// Indicates whether the article is a main article.
    /// </summary>
    public bool? IsHoofdartikel { get; set; }

    /// <summary>
    /// The sub-articles of the main article.
    /// </summary>
    public IReadOnlyList<SubArticleModel>? Subartikelen { get; set; }
}
