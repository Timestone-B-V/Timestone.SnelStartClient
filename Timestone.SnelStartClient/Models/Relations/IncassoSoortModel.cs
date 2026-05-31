using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Relations;

/// <summary>
/// Represents the direct debit type that applies to a relation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum IncassoSoortModel
{
    /// <summary>
    /// No direct debit type is configured for the relation.
    /// </summary>
    Geen,

    /// <summary>
    /// The relation uses the Core direct debit type.
    /// </summary>
    Core,

    /// <summary>
    /// The relation uses the B2B direct debit type.
    /// </summary>
    [EnumMember(Value = "B2B")]
    B2B
}
