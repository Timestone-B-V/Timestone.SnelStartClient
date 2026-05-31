using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for documents.
/// </summary>
public interface IDocumentsRepository
{
    /// <summary>
    /// Gets a document by its identifier.
    /// </summary>
    Task<DocumentModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all document references by their document type and parent identifier.
    /// </summary>
    Task<IReadOnlyList<SaleEntryAttachmentReferenceModel>> GetByTypeAsync(DocumentTypeModel documentType, Guid parentIdentifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new document for the specified document type.
    /// </summary>
    Task<DocumentIdentifierModel?> CreateAsync(DocumentTypeModel documentType, DocumentModel document, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a document.
    /// </summary>
    Task<DocumentIdentifierModel?> UpdateAsync(Guid id, DocumentModel document, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a document by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
