using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// An extra field as returned on different resources.
/// </summary>
public class ExtraFieldModel : SnelStartModel
{
    /// <summary>
    /// The name of the extra field.
    /// </summary>
    public string? Naam { get; set; }

    /// <summary>
    /// The value of the extra field.
    /// </summary>
    public JToken? Waarde { get; set; }
}
