using Timestone.SnelStartClient.Models.Banking;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Typed OData query options for retrieving bank entries.
/// </summary>
public sealed class BankEntryQueryOptions : ODataQueryOptions<BankEntryModel>;