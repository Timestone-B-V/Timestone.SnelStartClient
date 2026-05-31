using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Purchases;

/// <summary>
/// Status of creating a purchase entry from an attachment.
/// </summary>
public class CreateFromAttachmentStatusModel : DynamicResponseModel
{
    public string? InstanceId { get; set; }

    public CreateFromAttachmentStateModel? Status { get; set; }

    public Guid? InkoopboekingId { get; set; }
}
