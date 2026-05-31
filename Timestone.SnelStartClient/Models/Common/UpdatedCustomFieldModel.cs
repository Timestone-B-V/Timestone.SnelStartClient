using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// A custom field to update.
/// </summary>
public class UpdatedCustomFieldModel : SnelStartModel
{
    /// <summary>
    /// The name of the custom field.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The new value of the custom field.
    /// </summary>
    public JToken? Value { get; set; }
}
