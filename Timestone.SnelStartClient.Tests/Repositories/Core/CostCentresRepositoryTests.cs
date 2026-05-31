using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class CostCentresRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenCalled_ForwardsGetRequestToCostCentresEndpoint()
    {
        var expectedCostCentres = new List<CostCentreModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedCostCentres);
        ICostCentresRepository repository = new CostCentresRepository(requestExecutor);

        var result = await repository.ListAsync();

        Assert.Equal(expectedCostCentres, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "kostenplaatsen");
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToCostCentreEndpoint()
    {
        var costCentreId = Guid.NewGuid();
        var expectedCostCentre = new CostCentreModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedCostCentre);
        ICostCentresRepository repository = new CostCentresRepository(requestExecutor);

        var result = await repository.GetAsync(costCentreId);

        Assert.Same(expectedCostCentre, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"kostenplaatsen/{costCentreId}");
    }

    [Fact]
    public async Task CreateAsync_WhenCostCentreIsProvided_ForwardsPostRequestToCostCentresEndpoint()
    {
        var costCentre = new CostCentreModel();
        var expectedCostCentre = new CostCentreModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedCostCentre);
        ICostCentresRepository repository = new CostCentresRepository(requestExecutor);

        var result = await repository.CreateAsync(costCentre);

        Assert.Same(expectedCostCentre, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "kostenplaatsen", costCentre);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndCostCentreAreProvided_ForwardsPutRequestToCostCentreEndpoint()
    {
        var costCentreId = Guid.NewGuid();
        var costCentre = new CostCentreModel();
        var expectedCostCentre = new CostCentreModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedCostCentre);
        ICostCentresRepository repository = new CostCentresRepository(requestExecutor);

        var result = await repository.UpdateAsync(costCentreId, costCentre);

        Assert.Same(expectedCostCentre, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"kostenplaatsen/{costCentreId}", costCentre);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToCostCentreEndpoint()
    {
        var costCentreId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        ICostCentresRepository repository = new CostCentresRepository(requestExecutor);

        var result = await repository.DeleteAsync(costCentreId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"kostenplaatsen/{costCentreId}");
    }
}
