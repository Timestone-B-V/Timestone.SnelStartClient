using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the type of a journal.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum JournalTypeModel
{
    /// <summary>
    /// No journal type.
    /// </summary>
    Geen,

    /// <summary>
    /// Cash journal.
    /// </summary>
    Kas,

    /// <summary>
    /// Bank journal.
    /// </summary>
    Bank,

    /// <summary>
    /// Sales journal.
    /// </summary>
    Verkoop,

    /// <summary>
    /// Purchase journal.
    /// </summary>
    Inkoop,

    /// <summary>
    /// Memorial journal.
    /// </summary>
    Memoriaal,

    /// <summary>
    /// Balance journal.
    /// </summary>
    Balans,
}
