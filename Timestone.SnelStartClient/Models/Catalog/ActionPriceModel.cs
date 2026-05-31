using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Model of an action price.
/// </summary>
public class ActionPriceModel : SnelStartResource
{
    /// <summary>
    /// The description.
    /// </summary>
    public string? Omschrijving { get; set; }

    /// <summary>
    /// The start date.
    /// </summary>
    public DateTimeOffset? Startdatum { get; set; }

    /// <summary>
    /// The end date.
    /// </summary>
    public DateTimeOffset? Einddatum { get; set; }

    /// <summary>
    /// The status.
    /// </summary>
    public PriceStatusModel? Status { get; set; }

    /// <summary>
    /// Article prices within the action price.
    /// </summary>
    public IReadOnlyList<ActionPriceArticleModel>? ArtikelPrijzen { get; set; }
}
