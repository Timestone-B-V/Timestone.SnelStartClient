using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Query options for the status of creating from an attachment.
/// </summary>
public sealed class AttachmentStatusQueryOptions
{
    /// <summary>
    /// The instance identifier.
    /// </summary>
    [QueryName("instanceId")]
    public string InstanceId { get; set; } = string.Empty;
}