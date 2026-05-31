using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for reports.
/// </summary>
public interface IReportsRepository
{
    /// <summary>
    /// Gets a column balance for the specified date range.
    /// </summary>
    Task<ReportResultModel?> GetColumnBalanceAsync(DateRangeQueryOptions queryOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a period balance for the specified date range.
    /// </summary>
    Task<ReportResultModel?> GetPeriodBalanceAsync(DateRangeQueryOptions queryOptions, CancellationToken cancellationToken = default);
}
