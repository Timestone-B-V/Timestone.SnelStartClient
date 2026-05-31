using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Purchases;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Purchases;

public sealed class PurchaseInvoicesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToPurchaseInvoicesEndpoint()
    {
        var queryOptions = new PurchaseInvoiceQueryOptions();
        var expectedInvoices = new List<PurchaseInvoiceModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedInvoices);
        IPurchaseInvoicesRepository repository = new PurchaseInvoicesRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedInvoices, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "inkoopfacturen", query: queryOptions);
    }
}
