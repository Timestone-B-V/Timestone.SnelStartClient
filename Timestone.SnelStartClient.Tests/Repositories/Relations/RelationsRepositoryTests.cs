using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Models.Relations;
using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Relations;
using Timestone.SnelStartClient.Tests.TestDoubles;

namespace Timestone.SnelStartClient.Tests.Repositories.Relations;

public sealed class RelationsRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToRelationsEndpoint()
    {
        var queryOptions = new RelationQueryOptions();
        var expectedRelations = new List<RelationModel> { new() };
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedRelations)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedRelations, result);
        Assert.Equal(HttpMethod.Get, requestExecutor.LastMethod);
        Assert.Equal("relaties", requestExecutor.LastPath);
        Assert.Null(requestExecutor.LastBody);
        Assert.Same(queryOptions, requestExecutor.LastQuery);
    }

    [Fact]
    public async Task GetAsync_WhenRelationIdentifierIsProvided_ForwardsGetRequestToRelationEndpoint()
    {
        var relationId = Guid.NewGuid();
        var expectedRelation = new RelationModel();
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedRelation)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.GetAsync(relationId);

        Assert.Same(expectedRelation, result);
        Assert.Equal(HttpMethod.Get, requestExecutor.LastMethod);
        Assert.Equal($"relaties/{relationId}", requestExecutor.LastPath);
        Assert.Null(requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }

    [Fact]
    public async Task CreateAsync_WhenRelationIsProvided_ForwardsPostRequestToRelationsEndpoint()
    {
        var relation = new RelationModel();
        var expectedRelation = new RelationModel();
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedRelation)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.CreateAsync(relation);

        Assert.Same(expectedRelation, result);
        Assert.Equal(HttpMethod.Post, requestExecutor.LastMethod);
        Assert.Equal("relaties", requestExecutor.LastPath);
        Assert.Same(relation, requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }

    [Fact]
    public async Task UpdateAsync_WhenRelationIdentifierAndRelationAreProvided_ForwardsPutRequestToRelationEndpoint()
    {
        var relationId = Guid.NewGuid();
        var relation = new RelationModel();
        var expectedRelation = new RelationModel();
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedRelation)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.UpdateAsync(relationId, relation);

        Assert.Same(expectedRelation, result);
        Assert.Equal(HttpMethod.Put, requestExecutor.LastMethod);
        Assert.Equal($"relaties/{relationId}", requestExecutor.LastPath);
        Assert.Same(relation, requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }

    [Fact]
    public async Task DeleteAsync_WhenRelationIdentifierIsProvided_ForwardsDeleteRequestToRelationEndpoint()
    {
        var relationId = Guid.NewGuid();
        var requestExecutor = new RecordingRequestExecutor();
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.DeleteAsync(relationId);

        Assert.True(result);
        Assert.Equal(HttpMethod.Delete, requestExecutor.LastMethod);
        Assert.Equal($"relaties/{relationId}", requestExecutor.LastPath);
        Assert.Null(requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }

    [Fact]
    public async Task GetCustomFieldsAsync_WhenRelationIdentifierIsProvided_ForwardsGetRequestToCustomFieldsEndpoint()
    {
        var relationId = Guid.NewGuid();
        var expectedCustomFields = new RelationCustomFieldsModel();
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedCustomFields)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.GetCustomFieldsAsync(relationId);

        Assert.Same(expectedCustomFields, result);
        Assert.Equal(HttpMethod.Get, requestExecutor.LastMethod);
        Assert.Equal($"relaties/{relationId}/customFields", requestExecutor.LastPath);
        Assert.Null(requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }

    [Fact]
    public async Task UpdateCustomFieldsAsync_WhenPayloadIsProvided_ForwardsPutRequestToCustomFieldsEndpoint()
    {
        var relationId = Guid.NewGuid();
        var customFields = new UpdatedRelationCustomFieldsModel();
        var expectedCustomFields = new RelationCustomFieldsModel();
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedCustomFields)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.UpdateCustomFieldsAsync(relationId, customFields);

        Assert.Same(expectedCustomFields, result);
        Assert.Equal(HttpMethod.Put, requestExecutor.LastMethod);
        Assert.Equal($"relaties/{relationId}/customFields", requestExecutor.LastPath);
        Assert.Same(customFields, requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }

    [Fact]
    public async Task GetContinuousDirectDebitAuthorizationsAsync_WhenRelationIdentifierIsProvided_ForwardsGetRequestToDirectDebitEndpoint()
    {
        var relationId = Guid.NewGuid();
        var expectedAuthorizations = new List<ContinuousDirectDebitAuthorizationModel> { new() };
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedAuthorizations)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.GetContinuousDirectDebitAuthorizationsAsync(relationId);

        Assert.Equal(expectedAuthorizations, result);
        Assert.Equal(HttpMethod.Get, requestExecutor.LastMethod);
        Assert.Equal($"relaties/{relationId}/doorlopendeincassomachtigingen", requestExecutor.LastPath);
        Assert.Null(requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }

    [Fact]
    public async Task GetPurchaseEntriesAsync_WhenRelationIdentifierIsProvided_ForwardsGetRequestToPurchaseEntriesEndpoint()
    {
        var relationId = Guid.NewGuid();
        var expectedPurchaseEntries = new List<PurchaseEntryModel> { new() };
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedPurchaseEntries)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.GetPurchaseEntriesAsync(relationId);

        Assert.Equal(expectedPurchaseEntries, result);
        Assert.Equal(HttpMethod.Get, requestExecutor.LastMethod);
        Assert.Equal($"relaties/{relationId}/inkoopboekingen", requestExecutor.LastPath);
        Assert.Null(requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }

    [Fact]
    public async Task GetSaleEntriesAsync_WhenRelationIdentifierIsProvided_ForwardsGetRequestToSaleEntriesEndpoint()
    {
        var relationId = Guid.NewGuid();
        var expectedSaleEntries = new List<SaleEntryModel> { new() };
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(expectedSaleEntries)
        };
        IRelationsRepository repository = new RelationsRepository(requestExecutor);

        var result = await repository.GetSaleEntriesAsync(relationId);

        Assert.Equal(expectedSaleEntries, result);
        Assert.Equal(HttpMethod.Get, requestExecutor.LastMethod);
        Assert.Equal($"relaties/{relationId}/verkoopboekingen", requestExecutor.LastPath);
        Assert.Null(requestExecutor.LastBody);
        Assert.Null(requestExecutor.LastQuery);
    }
}
