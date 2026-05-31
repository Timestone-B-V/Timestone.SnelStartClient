using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Purchases;

/// <summary>
/// Represents the state of creating a purchase entry from an attachment.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum CreateFromAttachmentStateModel
{
    Running,
    Completed,
    ContinuedAsNew,
    Failed,
    Canceled,
    Terminated,
    Pending,
    NotFound,
    Unknown,
}
