using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents a document content resource.
/// </summary>
public class DocumentModel : SnelStartResource
{
    /// <summary>
    /// Gets or sets the content of the document as a base64 encoded string.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the public identifier of the parent entity to which the document is linked.
    /// </summary>
    public Guid? ParentIdentifier { get; set; }

    /// <summary>
    /// Gets or sets the file name of the document.
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the document is read-only.
    /// </summary>
    public bool? ReadOnly { get; set; }
}
