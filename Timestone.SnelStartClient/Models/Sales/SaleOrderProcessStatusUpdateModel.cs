using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Payload for updating the process status of a sales order.
/// </summary>
public class SaleOrderProcessStatusUpdateModel : DynamicResponseModel
{
    public Guid? Id { get; set; }

    public SaleOrderProcessStatusModel? ProcesStatus { get; set; }
}
