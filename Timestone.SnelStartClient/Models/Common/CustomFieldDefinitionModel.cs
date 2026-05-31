using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// Definition of a custom field.
/// </summary>
public class CustomFieldDefinitionModel : SnelStartModel
{
    /// <summary>
    /// The name of the custom field.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The type of the custom field.
    /// </summary>
    public CustomFieldTypeModel? Type { get; set; }

    /// <summary>
    /// Additional properties on the definition.
    /// </summary>
    public IReadOnlyList<CustomFieldPropertyModel>? Properties { get; set; }

    /// <summary>
    /// The vertical position.
    /// </summary>
    public int? YPosition { get; set; }

    /// <summary>
    /// The horizontal position.
    /// </summary>
    public int? XPosition { get; set; }
}
