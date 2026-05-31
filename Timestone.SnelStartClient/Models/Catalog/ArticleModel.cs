using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Creates a new article or represents an article from the administration.
/// </summary>
public class ArticleModel : SnelStartResource
{
    /// <summary>
    /// The article code.
    /// </summary>
    public string? Artikelcode { get; set; }

    /// <summary>
    /// The description.
    /// </summary>
    public string? Omschrijving { get; set; }

    /// <summary>
    /// The item department.
    /// </summary>
    public SnelStartReference? ArtikelOmzetgroep { get; set; }

    /// <summary>
    /// The sales price.
    /// </summary>
    public decimal? Verkoopprijs { get; set; }

    /// <summary>
    /// The purchase price.
    /// </summary>
    public decimal? Inkoopprijs { get; set; }

    /// <summary>
    /// The unit.
    /// </summary>
    public string? Eenheid { get; set; }

    /// <summary>
    /// The modification date.
    /// </summary>
    public DateTimeOffset? ModifiedOn { get; set; }

    /// <summary>
    /// The relation.
    /// </summary>
    public SnelStartReference? Relatie { get; set; }

    /// <summary>
    /// Indicates whether the article is inactive.
    /// </summary>
    public bool? IsNonActief { get; set; }

    /// <summary>
    /// Indicates whether stock control is active.
    /// </summary>
    public bool? VoorraadControle { get; set; }

    /// <summary>
    /// The technical stock.
    /// </summary>
    public decimal? TechnischeVoorraad { get; set; }

    /// <summary>
    /// The available stock.
    /// </summary>
    public decimal? VrijeVoorraad { get; set; }

    /// <summary>
    /// The extra fields.
    /// </summary>
    public IReadOnlyList<ExtraFieldModel>? ExtraVelden { get; set; }
}
