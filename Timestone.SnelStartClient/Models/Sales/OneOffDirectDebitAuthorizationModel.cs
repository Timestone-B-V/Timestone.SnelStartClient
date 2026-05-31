using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// One-off direct debit authorization.
/// </summary>
public class OneOffDirectDebitAuthorizationModel : SnelStartModel
{
    public string? Kenmerk { get; set; }

    public string? Omschrijving { get; set; }

    public DateTimeOffset? Datum { get; set; }
}
