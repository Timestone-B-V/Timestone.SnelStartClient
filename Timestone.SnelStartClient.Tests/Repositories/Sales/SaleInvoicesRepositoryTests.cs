using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Sales;

public sealed class SaleInvoicesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToSaleInvoicesEndpoint()
    {
        var queryOptions = new SaleInvoiceQueryOptions();
        var expectedInvoices = new List<SaleInvoiceModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedInvoices);
        ISaleInvoicesRepository repository = new SaleInvoicesRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedInvoices, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "verkoopfacturen", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToSaleInvoiceEndpoint()
    {
        var saleInvoiceId = Guid.NewGuid();
        var expectedInvoice = new SaleInvoiceModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedInvoice);
        ISaleInvoicesRepository repository = new SaleInvoicesRepository(requestExecutor);

        var result = await repository.GetAsync(saleInvoiceId);

        Assert.Same(expectedInvoice, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"verkoopfacturen/{saleInvoiceId}");
    }

    [Fact]
    public async Task GetUblAsync_WhenIdentifierIsProvided_ForwardsGetRequestToSaleInvoiceUblEndpoint()
    {
        var saleInvoiceId = Guid.NewGuid();
        var expectedUbl = new SaleInvoiceUblModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedUbl);
        ISaleInvoicesRepository repository = new SaleInvoicesRepository(requestExecutor);

        var result = await repository.GetUblAsync(saleInvoiceId);

        Assert.Same(expectedUbl, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"verkoopfacturen/{saleInvoiceId}/ubl");
    }
}
