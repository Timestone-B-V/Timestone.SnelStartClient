using Timestone.SnelStartClient.Models.Banking;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Typed OData query options for retrieving cash entries.
/// </summary>
public sealed class CashEntryQueryOptions : ODataQueryOptions<CashEntryModel>;