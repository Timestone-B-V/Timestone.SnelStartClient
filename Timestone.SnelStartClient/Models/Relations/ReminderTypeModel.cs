using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Relations;

/// <summary>
/// Represents the reminder type configured for a relation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ReminderTypeModel
{
    Nee,
    Onderneming,
    Consument,
}
