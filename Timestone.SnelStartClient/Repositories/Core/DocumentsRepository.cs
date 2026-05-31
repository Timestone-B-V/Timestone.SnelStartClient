using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for documents.
/// </summary>
internal sealed class DocumentsRepository : SnelStartRepositoryBase, IDocumentsRepository
{
    /// <summary>
    /// Initializes a new repository for documents.
    /// </summary>
    public DocumentsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<DocumentModel?> IDocumentsRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<DocumentModel>($"documenten/{id}", cancellationToken: cancellationToken);

    Task<IReadOnlyList<SaleEntryAttachmentReferenceModel>> IDocumentsRepository.GetByTypeAsync(DocumentTypeModel documentType, Guid parentIdentifier, CancellationToken cancellationToken)
        => GetListAsync<SaleEntryAttachmentReferenceModel>($"documenten/{documentType}/{parentIdentifier}", cancellationToken: cancellationToken);

    Task<DocumentIdentifierModel?> IDocumentsRepository.CreateAsync(DocumentTypeModel documentType, DocumentModel document, CancellationToken cancellationToken)
        => PostAsync<DocumentIdentifierModel>($"documenten/{documentType}", document, cancellationToken: cancellationToken);

    Task<DocumentIdentifierModel?> IDocumentsRepository.UpdateAsync(Guid id, DocumentModel document, CancellationToken cancellationToken)
        => PutAsync<DocumentIdentifierModel>($"documenten/{id}", document, cancellationToken: cancellationToken);

    Task<bool> IDocumentsRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"documenten/{id}", cancellationToken);
}