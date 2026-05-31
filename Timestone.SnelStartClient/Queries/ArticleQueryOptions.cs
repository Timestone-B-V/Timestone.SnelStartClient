using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Query options for retrieving articles.
/// </summary>
public sealed class ArticleQueryOptions : ODataQueryOptions<ArticleQueryModel>
{
    /// <summary>
    /// The optional identifier of the relation for which the price agreement must be added.
    /// </summary>
    [QueryName("relatieId")]
    public Guid? RelationId { get; set; }

    /// <summary>
    /// The optionally provided quantity for which the price agreement must be determined.
    /// </summary>
    [QueryName("aantal")]
    public int? Amount { get; set; }
}