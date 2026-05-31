using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Query options for reports.
/// </summary>
public sealed class DateRangeQueryOptions
{
    /// <summary>
    /// The start date of the report.
    /// </summary>
    [QueryName("start")]
    public DateTimeOffset Start { get; set; }

    /// <summary>
    /// The end date of the report.
    /// </summary>
    [QueryName("end")]
    public DateTimeOffset End { get; set; }
}