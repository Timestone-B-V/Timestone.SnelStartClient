using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Payload for externally filing a VAT declaration.
/// </summary>
public class VatDeclarationExternalUpdateModel : SnelStartModel
{
    /// <summary>
    /// Indicates whether the declaration has been filed externally.
    /// </summary>
    public bool IsExternAangegeven { get; set; }
}
