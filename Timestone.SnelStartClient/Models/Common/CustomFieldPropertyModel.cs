using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// Property within a custom field definition.
/// </summary>
public class CustomFieldPropertyModel : SnelStartModel
{
    /// <summary>
    /// The name of the property.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The value of the property.
    /// </summary>
    public JToken? Value { get; set; }
}
