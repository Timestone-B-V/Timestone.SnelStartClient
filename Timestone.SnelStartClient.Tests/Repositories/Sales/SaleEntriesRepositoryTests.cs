using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Sales;

public sealed class SaleEntriesRepositoryTests
{
    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToSaleEntryEndpoint()
    {
        var saleEntryId = Guid.NewGuid();
        var expectedSaleEntry = new SaleEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedSaleEntry);
        ISaleEntriesRepository repository = new SaleEntriesRepository(requestExecutor);

        var result = await repository.GetAsync(saleEntryId);

        Assert.Same(expectedSaleEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"verkoopboekingen/{saleEntryId}");
    }

    [Fact]
    public async Task CreateAsync_WhenSaleEntryIsProvided_ForwardsPostRequestToSaleEntriesEndpoint()
    {
        var saleEntry = new SaleEntryModel();
        var expectedSaleEntry = new SaleEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedSaleEntry);
        ISaleEntriesRepository repository = new SaleEntriesRepository(requestExecutor);

        var result = await repository.CreateAsync(saleEntry);

        Assert.Same(expectedSaleEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "verkoopboekingen", saleEntry);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndSaleEntryAreProvided_ForwardsPutRequestToSaleEntryEndpoint()
    {
        var saleEntryId = Guid.NewGuid();
        var saleEntry = new SaleEntryModel();
        var expectedSaleEntry = new SaleEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedSaleEntry);
        ISaleEntriesRepository repository = new SaleEntriesRepository(requestExecutor);

        var result = await repository.UpdateAsync(saleEntryId, saleEntry);

        Assert.Same(expectedSaleEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"verkoopboekingen/{saleEntryId}", saleEntry);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToSaleEntryEndpoint()
    {
        var saleEntryId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        ISaleEntriesRepository repository = new SaleEntriesRepository(requestExecutor);

        var result = await repository.DeleteAsync(saleEntryId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"verkoopboekingen/{saleEntryId}");
    }
}
