using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class CountriesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenCalled_ForwardsGetRequestToCountriesEndpoint()
    {
        var expectedCountries = new List<CountryModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedCountries);
        ICountriesRepository repository = new CountriesRepository(requestExecutor);

        var result = await repository.ListAsync();

        Assert.Equal(expectedCountries, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "landen");
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToCountryEndpoint()
    {
        var countryId = Guid.NewGuid();
        var expectedCountry = new CountryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedCountry);
        ICountriesRepository repository = new CountriesRepository(requestExecutor);

        var result = await repository.GetAsync(countryId);

        Assert.Same(expectedCountry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"landen/{countryId}");
    }
}
