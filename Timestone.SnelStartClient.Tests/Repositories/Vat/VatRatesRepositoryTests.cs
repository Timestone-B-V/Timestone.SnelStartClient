using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Repositories.Vat;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Vat;

public sealed class VatRatesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenCalled_ForwardsGetRequestToVatRatesEndpoint()
    {
        var expectedRates = new List<VatRateModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedRates);
        IVatRatesRepository repository = new VatRatesRepository(requestExecutor);

        var result = await repository.ListAsync();

        Assert.Equal(expectedRates, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "btwtarieven");
    }
}
