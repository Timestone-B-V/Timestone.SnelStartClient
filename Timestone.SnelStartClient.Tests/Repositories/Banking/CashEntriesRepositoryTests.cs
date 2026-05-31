using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Banking;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Banking;

public sealed class CashEntriesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToCashEntriesEndpoint()
    {
        var queryOptions = new CashEntryQueryOptions();
        var expectedEntries = new List<CashEntryModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedEntries);
        ICashEntriesRepository repository = new CashEntriesRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedEntries, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "kasboekingen", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToCashEntryEndpoint()
    {
        var entryId = Guid.NewGuid();
        var expectedEntry = new CashEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedEntry);
        ICashEntriesRepository repository = new CashEntriesRepository(requestExecutor);

        var result = await repository.GetAsync(entryId);

        Assert.Same(expectedEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"kasboekingen/{entryId}");
    }

    [Fact]
    public async Task CreateAsync_WhenEntryIsProvided_ForwardsPostRequestToCashEntriesEndpoint()
    {
        var cashEntry = new CashEntryModel();
        var expectedEntry = new CashEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedEntry);
        ICashEntriesRepository repository = new CashEntriesRepository(requestExecutor);

        var result = await repository.CreateAsync(cashEntry);

        Assert.Same(expectedEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "kasboekingen", cashEntry);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndEntryAreProvided_ForwardsPutRequestToCashEntryEndpoint()
    {
        var entryId = Guid.NewGuid();
        var cashEntry = new CashEntryModel();
        var expectedEntry = new CashEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedEntry);
        ICashEntriesRepository repository = new CashEntriesRepository(requestExecutor);

        var result = await repository.UpdateAsync(entryId, cashEntry);

        Assert.Same(expectedEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"kasboekingen/{entryId}", cashEntry);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToCashEntryEndpoint()
    {
        var entryId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        ICashEntriesRepository repository = new CashEntriesRepository(requestExecutor);

        var result = await repository.DeleteAsync(entryId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"kasboekingen/{entryId}");
    }
}
