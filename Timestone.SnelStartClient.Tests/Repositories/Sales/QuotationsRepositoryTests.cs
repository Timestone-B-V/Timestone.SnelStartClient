using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Sales;

public sealed class QuotationsRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToQuotationsEndpoint()
    {
        var queryOptions = new QuotationQueryOptions();
        var expectedQuotations = new List<QuotationModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedQuotations);
        IQuotationsRepository repository = new QuotationsRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedQuotations, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "offertes", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToQuotationEndpoint()
    {
        var quotationId = Guid.NewGuid();
        var expectedQuotation = new QuotationModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedQuotation);
        IQuotationsRepository repository = new QuotationsRepository(requestExecutor);

        var result = await repository.GetAsync(quotationId);

        Assert.Same(expectedQuotation, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"offertes/{quotationId}");
    }

    [Fact]
    public async Task CreateAsync_WhenQuotationIsProvided_ForwardsPostRequestToQuotationsEndpoint()
    {
        var quotation = new QuotationModel();
        var expectedQuotation = new QuotationModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedQuotation);
        IQuotationsRepository repository = new QuotationsRepository(requestExecutor);

        var result = await repository.CreateAsync(quotation);

        Assert.Same(expectedQuotation, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "offertes", quotation);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndQuotationAreProvided_ForwardsPutRequestToQuotationEndpoint()
    {
        var quotationId = Guid.NewGuid();
        var quotation = new QuotationModel();
        var expectedQuotation = new QuotationModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedQuotation);
        IQuotationsRepository repository = new QuotationsRepository(requestExecutor);

        var result = await repository.UpdateAsync(quotationId, quotation);

        Assert.Same(expectedQuotation, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"offertes/{quotationId}", quotation);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToQuotationEndpoint()
    {
        var quotationId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        IQuotationsRepository repository = new QuotationsRepository(requestExecutor);

        var result = await repository.DeleteAsync(quotationId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"offertes/{quotationId}");
    }
}
