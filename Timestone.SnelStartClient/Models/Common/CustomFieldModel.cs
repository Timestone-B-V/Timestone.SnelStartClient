using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// A custom field including its definition and current value.
/// </summary>
public class CustomFieldModel : SnelStartModel
{
    /// <summary>
    /// The definition of the custom field.
    /// </summary>
    public CustomFieldDefinitionModel? Definition { get; set; }

    /// <summary>
    /// The value of the custom field.
    /// </summary>
    public JToken? Value { get; set; }
}
