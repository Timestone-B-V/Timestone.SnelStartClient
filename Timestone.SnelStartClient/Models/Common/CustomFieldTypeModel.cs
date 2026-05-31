using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// Represents the type of a custom field definition.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum CustomFieldTypeModel
{
    Text,
    Integer,
    Money,
    Float,
    DateTime,
    Boolean,
    Enum,
    ByteArray,
}
