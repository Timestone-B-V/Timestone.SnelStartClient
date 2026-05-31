using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Catalog;

public sealed class PriceAgreementsRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToPriceAgreementsEndpoint()
    {
        var queryOptions = new PriceAgreementQueryOptions();
        var expectedAgreements = new List<PriceAgreementModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedAgreements);
        IPriceAgreementsRepository repository = new PriceAgreementsRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedAgreements, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "prijsafspraken", query: queryOptions);
    }
}
