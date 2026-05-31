using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Relations;

/// <summary>
/// Payload for updating relation custom fields.
/// </summary>
public class UpdatedRelationCustomFieldsModel : SnelStartModel
{
    /// <summary>
    /// Customer fields to update.
    /// </summary>
    public IReadOnlyList<UpdatedCustomFieldModel>? KlantCustomFields { get; set; }

    /// <summary>
    /// Supplier fields to update.
    /// </summary>
    public IReadOnlyList<UpdatedCustomFieldModel>? LeverancierCustomFields { get; set; }
}
