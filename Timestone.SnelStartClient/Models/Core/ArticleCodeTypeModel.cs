using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the format used for article codes.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ArticleCodeTypeModel
{
    /// <summary>
    /// Numeric article codes.
    /// </summary>
    Numeriek,

    /// <summary>
    /// Alphanumeric article codes.
    /// </summary>
    Alfanumeriek,
}
