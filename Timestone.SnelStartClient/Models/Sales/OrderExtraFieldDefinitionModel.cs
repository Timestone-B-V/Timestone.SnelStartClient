using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Definition of an extra order field.
/// </summary>
public class OrderExtraFieldDefinitionModel : SnelStartModel
{
    public int? VeldNummer { get; set; }

    public string? Omschrijving { get; set; }

    public string? IngaveMasker { get; set; }

    public OrderExtraFieldTypeModel? SoortVeld { get; set; }

    public int? MaximumTekstLengte { get; set; }
}
