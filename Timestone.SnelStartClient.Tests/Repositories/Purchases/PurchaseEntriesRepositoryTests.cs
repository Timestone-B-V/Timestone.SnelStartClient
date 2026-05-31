using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Purchases;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Purchases;

public sealed class PurchaseEntriesRepositoryTests
{
    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToPurchaseEntryEndpoint()
    {
        var purchaseEntryId = Guid.NewGuid();
        var expectedPurchaseEntry = new PurchaseEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedPurchaseEntry);
        IPurchaseEntriesRepository repository = new PurchaseEntriesRepository(requestExecutor);

        var result = await repository.GetAsync(purchaseEntryId);

        Assert.Same(expectedPurchaseEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"inkoopboekingen/{purchaseEntryId}");
    }

    [Fact]
    public async Task CreateAsync_WhenPurchaseEntryIsProvided_ForwardsPostRequestToPurchaseEntriesEndpoint()
    {
        var purchaseEntry = new PurchaseEntryModel();
        var expectedPurchaseEntry = new PurchaseEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedPurchaseEntry);
        IPurchaseEntriesRepository repository = new PurchaseEntriesRepository(requestExecutor);

        var result = await repository.CreateAsync(purchaseEntry);

        Assert.Same(expectedPurchaseEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "inkoopboekingen", purchaseEntry);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndPurchaseEntryAreProvided_ForwardsPutRequestToPurchaseEntryEndpoint()
    {
        var purchaseEntryId = Guid.NewGuid();
        var purchaseEntry = new PurchaseEntryModel();
        var expectedPurchaseEntry = new PurchaseEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedPurchaseEntry);
        IPurchaseEntriesRepository repository = new PurchaseEntriesRepository(requestExecutor);

        var result = await repository.UpdateAsync(purchaseEntryId, purchaseEntry);

        Assert.Same(expectedPurchaseEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"inkoopboekingen/{purchaseEntryId}", purchaseEntry);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToPurchaseEntryEndpoint()
    {
        var purchaseEntryId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        IPurchaseEntriesRepository repository = new PurchaseEntriesRepository(requestExecutor);

        var result = await repository.DeleteAsync(purchaseEntryId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"inkoopboekingen/{purchaseEntryId}");
    }

    [Fact]
    public async Task CreateFromAttachmentAsync_WhenPayloadIsProvided_ForwardsPostRequestToCreateFromAttachmentEndpoint()
    {
        var payload = new DynamicResponseModel();
        var expectedStatus = new CreateFromAttachmentStatusModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedStatus);
        IPurchaseEntriesRepository repository = new PurchaseEntriesRepository(requestExecutor);

        var result = await repository.CreateFromAttachmentAsync(payload);

        Assert.Same(expectedStatus, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "inkoopboekingen/CreateFromAttachment", payload);
    }

    [Fact]
    public async Task GetCreateFromAttachmentStatusAsync_WhenInstanceIdentifierIsProvided_ForwardsGetRequestWithAttachmentStatusQuery()
    {
        var expectedStatus = new CreateFromAttachmentStatusModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedStatus);
        IPurchaseEntriesRepository repository = new PurchaseEntriesRepository(requestExecutor);

        var result = await repository.GetCreateFromAttachmentStatusAsync("instance-id");

        Assert.Same(expectedStatus, result);
        Assert.IsType<AttachmentStatusQueryOptions>(requestExecutor.LastQuery);
        Assert.Equal("instance-id", ((AttachmentStatusQueryOptions)requestExecutor.LastQuery!).InstanceId);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "inkoopboekingen/GetCreateFromAttachmentStatus", query: requestExecutor.LastQuery);
    }

    [Fact]
    public async Task PostUblAsync_WhenPayloadIsProvided_ForwardsPostRequestToUblEndpoint()
    {
        var payload = new DynamicResponseModel();
        var expectedResponse = new PurchaseEntryUblResponseModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedResponse);
        IPurchaseEntriesRepository repository = new PurchaseEntriesRepository(requestExecutor);

        var result = await repository.PostUblAsync(payload);

        Assert.Same(expectedResponse, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "inkoopboekingen/ubl", payload);
    }
}
