using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class CompanyInfoRepositoryTests
{
    [Fact]
    public async Task GetAsync_WhenCalled_ForwardsGetRequestToCompanyInfoEndpoint()
    {
        var expectedCompanyInfo = new CompanyInfoModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedCompanyInfo);
        ICompanyInfoRepository repository = new CompanyInfoRepository(requestExecutor);

        var result = await repository.GetAsync();

        Assert.Same(expectedCompanyInfo, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "companyInfo");
    }

    [Fact]
    public async Task UpdateAsync_WhenCompanyInfoIsProvided_ForwardsPutRequestToCompanyInfoEndpoint()
    {
        var companyInfo = new CompanyInfoModel();
        var expectedCompanyInfo = new CompanyInfoModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedCompanyInfo);
        ICompanyInfoRepository repository = new CompanyInfoRepository(requestExecutor);

        var result = await repository.UpdateAsync(companyInfo);

        Assert.Same(expectedCompanyInfo, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, "companyInfo", companyInfo);
    }
}
