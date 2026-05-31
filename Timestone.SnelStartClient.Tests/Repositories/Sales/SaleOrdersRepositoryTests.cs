using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Sales;

public sealed class SaleOrdersRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToSaleOrdersEndpoint()
    {
        var queryOptions = new SaleOrderQueryOptions();
        var expectedOrders = new List<SaleOrderModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedOrders);
        ISaleOrdersRepository repository = new SaleOrdersRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedOrders, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "verkooporders", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToSaleOrderEndpoint()
    {
        var saleOrderId = Guid.NewGuid();
        var expectedOrder = new SaleOrderModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedOrder);
        ISaleOrdersRepository repository = new SaleOrdersRepository(requestExecutor);

        var result = await repository.GetAsync(saleOrderId);

        Assert.Same(expectedOrder, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"verkooporders/{saleOrderId}");
    }

    [Fact]
    public async Task CreateAsync_WhenSaleOrderIsProvided_ForwardsPostRequestToSaleOrdersEndpoint()
    {
        var saleOrder = new SaleOrderModel();
        var expectedOrder = new SaleOrderModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedOrder);
        ISaleOrdersRepository repository = new SaleOrdersRepository(requestExecutor);

        var result = await repository.CreateAsync(saleOrder);

        Assert.Same(expectedOrder, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "verkooporders", saleOrder);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndSaleOrderAreProvided_ForwardsPutRequestToSaleOrderEndpoint()
    {
        var saleOrderId = Guid.NewGuid();
        var saleOrder = new SaleOrderModel();
        var expectedOrder = new SaleOrderModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedOrder);
        ISaleOrdersRepository repository = new SaleOrdersRepository(requestExecutor);

        var result = await repository.UpdateAsync(saleOrderId, saleOrder);

        Assert.Same(expectedOrder, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"verkooporders/{saleOrderId}", saleOrder);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToSaleOrderEndpoint()
    {
        var saleOrderId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        ISaleOrdersRepository repository = new SaleOrdersRepository(requestExecutor);

        var result = await repository.DeleteAsync(saleOrderId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"verkooporders/{saleOrderId}");
    }

    [Fact]
    public async Task UpdateProcessStatusAsync_WhenIdentifierAndPayloadAreProvided_ForwardsPutRequestToProcessStatusEndpoint()
    {
        var saleOrderId = Guid.NewGuid();
        var payload = new SaleOrderProcessStatusUpdateModel();
        var expectedOrder = new SaleOrderModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedOrder);
        ISaleOrdersRepository repository = new SaleOrdersRepository(requestExecutor);

        var result = await repository.UpdateProcessStatusAsync(saleOrderId, payload);

        Assert.Same(expectedOrder, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"verkooporders/{saleOrderId}/ProcesStatus", payload);
    }
}
