using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the marking behavior used while importing bank statements.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum BankStatementImportMarkingBehaviorModel
{
    /// <summary>
    /// Mark only the most important entries.
    /// </summary>
    AlleenBelangrijkste,

    /// <summary>
    /// Always mark entries.
    /// </summary>
    Altijd,
}
