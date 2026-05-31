using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents a document reference returned for a parent document type.
/// </summary>
public class SaleEntryAttachmentReferenceModel : SnelStartResource
{
    /// <summary>
    /// Gets or sets the public identifier of the linked sales entry.
    /// </summary>
    public Guid? SaleEntryId { get; set; }

    /// <summary>
    /// Gets or sets the file name of the attachment.
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the attachment is read-only.
    /// </summary>
    public bool? ReadOnly { get; set; }
}
