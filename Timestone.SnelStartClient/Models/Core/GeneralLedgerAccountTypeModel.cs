using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the account type of a general ledger.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum GeneralLedgerAccountTypeModel
{
    /// <summary>
    /// Balance sheet account.
    /// </summary>
    Balans,

    /// <summary>
    /// Profit and loss account.
    /// </summary>
    WinstEnVerlies,
}
