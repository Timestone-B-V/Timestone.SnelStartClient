using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// General OData query options for endpoints where OData functionality is available.
/// According to the API reference, the current repository methods with OData query options also support <c>$select</c>.
/// </summary>
public class ODataQueryOptions
{
    /// <summary>
    /// The number of results to skip.
    /// </summary>
    [QueryName("$skip")]
    public int? Skip { get; set; }

    /// <summary>
    /// The maximum number of results.
    /// </summary>
    [QueryName("$top")]
    public int? Top { get; set; }

    /// <summary>
    /// The OData filter.
    /// </summary>
    [QueryName("$filter")]
    public string? Filter { get; set; }

    /// <summary>
    /// The OData order by expression.
    /// </summary>
    [QueryName("$orderby")]
    public string? OrderByExpression { get; set; }

    /// <summary>
    /// The OData select expression.
    /// </summary>
    [QueryName("$select")]
    public string? Select { get; set; }
}