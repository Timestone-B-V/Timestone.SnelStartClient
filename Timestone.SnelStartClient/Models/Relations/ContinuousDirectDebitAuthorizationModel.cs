using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Relations;

/// <summary>
/// Recurring direct debit authorization of a relation.
/// </summary>
public class ContinuousDirectDebitAuthorizationModel : SnelStartResource
{
    /// <summary>
    /// The reference.
    /// </summary>
    public string? Kenmerk { get; set; }

    /// <summary>
    /// The end date.
    /// </summary>
    public DateTimeOffset? AfsluitDatum { get; set; }

    /// <summary>
    /// The description.
    /// </summary>
    public string? Omschrijving { get; set; }

    /// <summary>
    /// The customer.
    /// </summary>
    public SnelStartReference? Klant { get; set; }

    /// <summary>
    /// The revocation date.
    /// </summary>
    public DateTimeOffset? IntrekkingsDatum { get; set; }
}
