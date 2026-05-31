using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Sub-article of an article.
/// </summary>
public class SubArticleModel : SnelStartResource
{
    /// <summary>
    /// The article code.
    /// </summary>
    public string? Artikelcode { get; set; }

    /// <summary>
    /// The quantity.
    /// </summary>
    public decimal? Aantal { get; set; }
}
