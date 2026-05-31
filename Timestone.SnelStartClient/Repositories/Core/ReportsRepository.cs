using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for reports.
/// </summary>
internal sealed class ReportsRepository : SnelStartRepositoryBase, IReportsRepository
{
    /// <summary>
    /// Initializes a new repository for reports.
    /// </summary>
    public ReportsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<ReportResultModel?> IReportsRepository.GetColumnBalanceAsync(DateRangeQueryOptions queryOptions, CancellationToken cancellationToken)
        => GetAsync<ReportResultModel>("rapportages/kolommenbalans", queryOptions, cancellationToken);

    Task<ReportResultModel?> IReportsRepository.GetPeriodBalanceAsync(DateRangeQueryOptions queryOptions, CancellationToken cancellationToken)
        => GetAsync<ReportResultModel>("rapportages/periodebalans", queryOptions, cancellationToken);
}