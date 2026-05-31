using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Catalog;

/// <summary>
/// Implementation of the repository for articles.
/// </summary>
internal sealed class ArticlesRepository : SnelStartRepositoryBase, IArticlesRepository
{
    /// <summary>
    /// Initializes a new repository for articles.
    /// </summary>
    public ArticlesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<ArticleQueryModel>> IArticlesRepository.ListAsync(ArticleQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<ArticleQueryModel>("artikelen", queryOptions, cancellationToken);

    Task<ArticleQueryModel?> IArticlesRepository.GetAsync(Guid id, ArticleQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetAsync<ArticleQueryModel>($"artikelen/{id}", queryOptions, cancellationToken);

    Task<ArticleModel?> IArticlesRepository.CreateAsync(ArticleModel article, CancellationToken cancellationToken)
        => PostAsync<ArticleModel>("artikelen", article, cancellationToken: cancellationToken);

    Task<ArticleModel?> IArticlesRepository.UpdateAsync(Guid id, ArticleModel article, CancellationToken cancellationToken)
        => PutAsync<ArticleModel>($"artikelen/{id}", article, cancellationToken: cancellationToken);

    Task<bool> IArticlesRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"artikelen/{id}", cancellationToken);

    Task<IReadOnlyList<CustomFieldModel>> IArticlesRepository.GetCustomFieldsAsync(Guid id, CancellationToken cancellationToken)
        => GetListAsync<CustomFieldModel>($"artikelen/{id}/customFields", cancellationToken: cancellationToken);

    async Task<IReadOnlyList<CustomFieldModel>> IArticlesRepository.UpdateCustomFieldsAsync(Guid id, IReadOnlyList<UpdatedCustomFieldModel> customFields, CancellationToken cancellationToken)
    {
        var result = await PutAsync<List<CustomFieldModel>>($"artikelen/{id}/customFields", customFields, cancellationToken: cancellationToken).ConfigureAwait(false);
        return result ?? [];
    }

    Task<IReadOnlyList<ArticlePriceAgreementModel>> IArticlesRepository.GetPriceAgreementsAsync(ArticlePriceAgreementQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<ArticlePriceAgreementModel>("artikelen/prijsafspraken", queryOptions, cancellationToken);
}