using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Vat;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Vat;

public sealed class VatRateIntlRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToVatRateIntlEndpoint()
    {
        var queryOptions = new VatRateIntlQueryOptions();
        var expectedRates = new List<VatRateIntlModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedRates);
        IVatRateIntlRepository repository = new VatRateIntlRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedRates, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "vatrates", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToVatRateIntlItemEndpoint()
    {
        var vatRateId = Guid.NewGuid();
        var expectedRate = new VatRateIntlModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedRate);
        IVatRateIntlRepository repository = new VatRateIntlRepository(requestExecutor);

        var result = await repository.GetAsync(vatRateId);

        Assert.Same(expectedRate, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"vatrates/{vatRateId}");
    }
}
