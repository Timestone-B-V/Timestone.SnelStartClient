using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class GeneralLedgersRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToGeneralLedgersEndpoint()
    {
        var queryOptions = new GeneralLedgerQueryOptions();
        var expectedGeneralLedgers = new List<GeneralLedgerModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedGeneralLedgers);
        IGeneralLedgersRepository repository = new GeneralLedgersRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedGeneralLedgers, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "grootboeken", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToGeneralLedgerEndpoint()
    {
        var generalLedgerId = Guid.NewGuid();
        var expectedGeneralLedger = new GeneralLedgerModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedGeneralLedger);
        IGeneralLedgersRepository repository = new GeneralLedgersRepository(requestExecutor);

        var result = await repository.GetAsync(generalLedgerId);

        Assert.Same(expectedGeneralLedger, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"grootboeken/{generalLedgerId}");
    }

    [Fact]
    public async Task CreateAsync_WhenGeneralLedgerIsProvided_ForwardsPostRequestToGeneralLedgersEndpoint()
    {
        var generalLedger = new GeneralLedgerModel();
        var expectedGeneralLedger = new GeneralLedgerModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedGeneralLedger);
        IGeneralLedgersRepository repository = new GeneralLedgersRepository(requestExecutor);

        var result = await repository.CreateAsync(generalLedger);

        Assert.Same(expectedGeneralLedger, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "grootboeken", generalLedger);
    }
}
