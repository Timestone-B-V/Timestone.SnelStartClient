using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class DocumentsRepositoryTests
{
    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToDocumentEndpoint()
    {
        var documentId = Guid.NewGuid();
        var expectedDocument = new DocumentModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDocument);
        IDocumentsRepository repository = new DocumentsRepository(requestExecutor);

        var result = await repository.GetAsync(documentId);

        Assert.Same(expectedDocument, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"documenten/{documentId}");
    }

    [Fact]
    public async Task GetByTypeAsync_WhenTypeAndIdentifierAreProvided_ForwardsGetRequestToTypedDocumentEndpoint()
    {
        var parentIdentifier = Guid.NewGuid();
        List<SaleEntryAttachmentReferenceModel> expectedDocuments = [new SaleEntryAttachmentReferenceModel()];
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDocuments);
        IDocumentsRepository repository = new DocumentsRepository(requestExecutor);

        var result = await repository.GetByTypeAsync(DocumentTypeModel.Verkoopboekingen, parentIdentifier);

        Assert.Same(expectedDocuments, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"documenten/Verkoopboekingen/{parentIdentifier}");
    }

    [Fact]
    public async Task CreateAsync_WhenTypeAndDocumentAreProvided_ForwardsPostRequestToTypedDocumentsEndpoint()
    {
        var document = new DocumentModel();
        var expectedDocument = new DocumentIdentifierModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDocument);
        IDocumentsRepository repository = new DocumentsRepository(requestExecutor);

        var result = await repository.CreateAsync(DocumentTypeModel.Verkoopboekingen, document);

        Assert.Same(expectedDocument, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "documenten/Verkoopboekingen", document);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndDocumentAreProvided_ForwardsPutRequestToDocumentEndpoint()
    {
        var documentId = Guid.NewGuid();
        var document = new DocumentModel();
        var expectedDocument = new DocumentIdentifierModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDocument);
        IDocumentsRepository repository = new DocumentsRepository(requestExecutor);

        var result = await repository.UpdateAsync(documentId, document);

        Assert.Same(expectedDocument, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"documenten/{documentId}", document);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToDocumentEndpoint()
    {
        var documentId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        IDocumentsRepository repository = new DocumentsRepository(requestExecutor);

        var result = await repository.DeleteAsync(documentId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"documenten/{documentId}");
    }

}
