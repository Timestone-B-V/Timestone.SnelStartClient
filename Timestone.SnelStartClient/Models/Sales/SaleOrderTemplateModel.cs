using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Model of a sales order template.
/// </summary>
public class SaleOrderTemplateModel : SnelStartResource
{
    public string? Omschrijving { get; set; }

    public bool? Nonactief { get; set; }

    public bool? PrijsIngaveExclusiefBtw { get; set; }

    public bool? NieuweOrdersBlokkeren { get; set; }

    public IReadOnlyList<OrderExtraFieldDefinitionModel>? ExtraHoofdVelden { get; set; }

    public IReadOnlyList<OrderExtraFieldDefinitionModel>? ExtraRegelVelden { get; set; }
}
