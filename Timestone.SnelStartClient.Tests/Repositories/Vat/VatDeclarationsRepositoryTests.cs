using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Vat;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Vat;

public sealed class VatDeclarationsRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToVatDeclarationsEndpoint()
    {
        var queryOptions = new VatDeclarationQueryOptions();
        var expectedDeclarations = new List<VatDeclarationModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDeclarations);
        IVatDeclarationsRepository repository = new VatDeclarationsRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedDeclarations, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "btwaangiftes", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToVatDeclarationEndpoint()
    {
        var declarationId = Guid.NewGuid();
        var expectedDeclaration = new VatDeclarationModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDeclaration);
        IVatDeclarationsRepository repository = new VatDeclarationsRepository(requestExecutor);

        var result = await repository.GetAsync(declarationId);

        Assert.Same(expectedDeclaration, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"btwaangiftes/{declarationId}");
    }

    [Fact]
    public async Task UpdateExternalAsync_WhenIdentifierAndPayloadAreProvided_ForwardsPutRequestToExternalUpdateEndpoint()
    {
        var declarationId = Guid.NewGuid();
        var payload = new VatDeclarationExternalUpdateModel();
        var expectedDeclaration = new VatDeclarationModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDeclaration);
        IVatDeclarationsRepository repository = new VatDeclarationsRepository(requestExecutor);

        var result = await repository.UpdateExternalAsync(declarationId, payload);

        Assert.Same(expectedDeclaration, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"btwaangiftes/{declarationId}/externAangeven", payload);
    }
}
