using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Catalog;

public sealed class ActionPricesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToActionPricesEndpoint()
    {
        var queryOptions = new ActionPriceQueryOptions();
        var expectedPrices = new List<ActionPriceModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedPrices);
        IActionPricesRepository repository = new ActionPricesRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedPrices, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "actieprijzen", query: queryOptions);
    }
}
