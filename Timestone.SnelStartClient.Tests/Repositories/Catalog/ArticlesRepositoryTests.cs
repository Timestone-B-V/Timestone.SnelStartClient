using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Catalog;

public sealed class ArticlesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToArticlesEndpoint()
    {
        var queryOptions = new ArticleQueryOptions();
        var expectedArticles = new List<ArticleQueryModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedArticles);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedArticles, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "artikelen", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierAndQueryOptionsAreProvided_ForwardsGetRequestToArticleEndpoint()
    {
        var articleId = Guid.NewGuid();
        var queryOptions = new ArticleQueryOptions();
        var expectedArticle = new ArticleQueryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedArticle);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.GetAsync(articleId, queryOptions);

        Assert.Same(expectedArticle, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"artikelen/{articleId}", query: queryOptions);
    }

    [Fact]
    public async Task CreateAsync_WhenArticleIsProvided_ForwardsPostRequestToArticlesEndpoint()
    {
        var article = new ArticleModel();
        var expectedArticle = new ArticleModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedArticle);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.CreateAsync(article);

        Assert.Same(expectedArticle, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "artikelen", article);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndArticleAreProvided_ForwardsPutRequestToArticleEndpoint()
    {
        var articleId = Guid.NewGuid();
        var article = new ArticleModel();
        var expectedArticle = new ArticleModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedArticle);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.UpdateAsync(articleId, article);

        Assert.Same(expectedArticle, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"artikelen/{articleId}", article);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToArticleEndpoint()
    {
        var articleId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.DeleteAsync(articleId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"artikelen/{articleId}");
    }

    [Fact]
    public async Task GetCustomFieldsAsync_WhenIdentifierIsProvided_ForwardsGetRequestToCustomFieldsEndpoint()
    {
        var articleId = Guid.NewGuid();
        var expectedFields = new List<CustomFieldModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedFields);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.GetCustomFieldsAsync(articleId);

        Assert.Equal(expectedFields, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"artikelen/{articleId}/customFields");
    }

    [Fact]
    public async Task UpdateCustomFieldsAsync_WhenExecutorReturnsFields_ForwardsPutRequestToCustomFieldsEndpoint()
    {
        var articleId = Guid.NewGuid();
        IReadOnlyList<UpdatedCustomFieldModel> customFields = [new UpdatedCustomFieldModel()];
        var expectedFields = new List<CustomFieldModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedFields);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.UpdateCustomFieldsAsync(articleId, customFields);

        Assert.Equal(expectedFields, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"artikelen/{articleId}/customFields", customFields);
    }

    [Fact]
    public async Task UpdateCustomFieldsAsync_WhenExecutorReturnsNull_ReturnsEmptyList()
    {
        var articleId = Guid.NewGuid();
        IReadOnlyList<UpdatedCustomFieldModel> customFields = [new UpdatedCustomFieldModel()];
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.UpdateCustomFieldsAsync(articleId, customFields);

        Assert.Empty(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"artikelen/{articleId}/customFields", customFields);
    }

    [Fact]
    public async Task GetPriceAgreementsAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToArticlePriceAgreementsEndpoint()
    {
        var queryOptions = new ArticlePriceAgreementQueryOptions();
        var expectedAgreements = new List<ArticlePriceAgreementModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedAgreements);
        IArticlesRepository repository = new ArticlesRepository(requestExecutor);

        var result = await repository.GetPriceAgreementsAsync(queryOptions);

        Assert.Equal(expectedAgreements, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "artikelen/prijsafspraken", query: queryOptions);
    }
}
