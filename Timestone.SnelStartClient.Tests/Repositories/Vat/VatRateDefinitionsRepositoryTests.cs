using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Vat;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Vat;

public sealed class VatRateDefinitionsRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToVatRateDefinitionsEndpoint()
    {
        var queryOptions = new VatRateDefinitionQueryOptions();
        var expectedDefinitions = new List<VatRateDefinitionModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDefinitions);
        IVatRateDefinitionsRepository repository = new VatRateDefinitionsRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedDefinitions, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "vatratedefinitions", query: queryOptions);
    }
}
