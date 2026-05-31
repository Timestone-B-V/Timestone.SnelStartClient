using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Catalog;

/// <summary>
/// Repository for articles.
/// </summary>
public interface IArticlesRepository
{
    /// <summary>
    /// Gets all available articles from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<ArticleQueryModel>> ListAsync(ArticleQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an article by its identifier and the optionally specified relation.
    /// </summary>
    Task<ArticleQueryModel?> GetAsync(Guid id, ArticleQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new article.
    /// </summary>
    Task<ArticleModel?> CreateAsync(ArticleModel article, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing article.
    /// </summary>
    Task<ArticleModel?> UpdateAsync(Guid id, ArticleModel article, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an active article by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all available custom fields for an article.
    /// </summary>
    Task<IReadOnlyList<CustomFieldModel>> GetCustomFieldsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the custom fields of an existing article.
    /// </summary>
    Task<IReadOnlyList<CustomFieldModel>> UpdateCustomFieldsAsync(Guid id, IReadOnlyList<UpdatedCustomFieldModel> customFields, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets price agreements for articles.
    /// </summary>
    Task<IReadOnlyList<ArticlePriceAgreementModel>> GetPriceAgreementsAsync(ArticlePriceAgreementQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);
}
