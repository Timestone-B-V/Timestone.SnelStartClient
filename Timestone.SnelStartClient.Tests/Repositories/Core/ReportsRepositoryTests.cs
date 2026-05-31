using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class ReportsRepositoryTests
{
    [Fact]
    public async Task GetColumnBalanceAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToColumnBalanceEndpoint()
    {
        var queryOptions = new DateRangeQueryOptions();
        var expectedReport = new ReportResultModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedReport);
        IReportsRepository repository = new ReportsRepository(requestExecutor);

        var result = await repository.GetColumnBalanceAsync(queryOptions);

        Assert.Same(expectedReport, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "rapportages/kolommenbalans", query: queryOptions);
    }

    [Fact]
    public async Task GetPeriodBalanceAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToPeriodBalanceEndpoint()
    {
        var queryOptions = new DateRangeQueryOptions();
        var expectedReport = new ReportResultModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedReport);
        IReportsRepository repository = new ReportsRepository(requestExecutor);

        var result = await repository.GetPeriodBalanceAsync(queryOptions);

        Assert.Same(expectedReport, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "rapportages/periodebalans", query: queryOptions);
    }
}
