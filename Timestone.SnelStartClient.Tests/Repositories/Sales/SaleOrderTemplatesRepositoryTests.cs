using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Sales;

public sealed class SaleOrderTemplatesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenCalled_ForwardsGetRequestToSaleOrderTemplatesEndpoint()
    {
        var expectedTemplates = new List<SaleOrderTemplateModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedTemplates);
        ISaleOrderTemplatesRepository repository = new SaleOrderTemplatesRepository(requestExecutor);

        var result = await repository.ListAsync();

        Assert.Equal(expectedTemplates, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "verkoopordersjablonen");
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToSaleOrderTemplateEndpoint()
    {
        var templateId = Guid.NewGuid();
        var expectedTemplate = new SaleOrderTemplateModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedTemplate);
        ISaleOrderTemplatesRepository repository = new SaleOrderTemplatesRepository(requestExecutor);

        var result = await repository.GetAsync(templateId);

        Assert.Same(expectedTemplate, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"verkoopordersjablonen/{templateId}");
    }
}
