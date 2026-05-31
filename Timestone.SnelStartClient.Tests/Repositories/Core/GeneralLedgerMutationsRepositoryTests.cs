using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class GeneralLedgerMutationsRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToGeneralLedgerMutationsEndpoint()
    {
        var queryOptions = new GeneralLedgerMutationQueryOptions();
        var expectedMutations = new List<GeneralLedgerMutationModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedMutations);
        IGeneralLedgerMutationsRepository repository = new GeneralLedgerMutationsRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedMutations, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "grootboekmutaties", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToGeneralLedgerMutationEndpoint()
    {
        var mutationId = Guid.NewGuid();
        var expectedMutation = new GeneralLedgerMutationModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedMutation);
        IGeneralLedgerMutationsRepository repository = new GeneralLedgerMutationsRepository(requestExecutor);

        var result = await repository.GetAsync(mutationId);

        Assert.Same(expectedMutation, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"grootboekmutaties/{mutationId}");
    }
}
