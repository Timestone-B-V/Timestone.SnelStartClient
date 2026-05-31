using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Relations;

/// <summary>
/// Custom fields of a relation, split by customer and supplier.
/// </summary>
public class RelationCustomFieldsModel : SnelStartModel
{
    /// <summary>
    /// The customer custom fields.
    /// </summary>
    public IReadOnlyList<CustomFieldModel>? KlantCustomFields { get; set; }

    /// <summary>
    /// The supplier custom fields.
    /// </summary>
    public IReadOnlyList<CustomFieldModel>? LeverancierCustomFields { get; set; }
}
