using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Banking;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Banking;

public sealed class BankEntriesRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenQueryOptionsAreProvided_ForwardsGetRequestToBankEntriesEndpoint()
    {
        var queryOptions = new BankEntryQueryOptions();
        var expectedEntries = new List<BankEntryModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedEntries);
        IBankEntriesRepository repository = new BankEntriesRepository(requestExecutor);

        var result = await repository.ListAsync(queryOptions);

        Assert.Equal(expectedEntries, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "bankboekingen", query: queryOptions);
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToBankEntryEndpoint()
    {
        var entryId = Guid.NewGuid();
        var expectedEntry = new BankEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedEntry);
        IBankEntriesRepository repository = new BankEntriesRepository(requestExecutor);

        var result = await repository.GetAsync(entryId);

        Assert.Same(expectedEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"bankboekingen/{entryId}");
    }

    [Fact]
    public async Task CreateAsync_WhenEntryIsProvided_ForwardsPostRequestToBankEntriesEndpoint()
    {
        var bankEntry = new BankEntryModel();
        var expectedEntry = new BankEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedEntry);
        IBankEntriesRepository repository = new BankEntriesRepository(requestExecutor);

        var result = await repository.CreateAsync(bankEntry);

        Assert.Same(expectedEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "bankboekingen", bankEntry);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndEntryAreProvided_ForwardsPutRequestToBankEntryEndpoint()
    {
        var entryId = Guid.NewGuid();
        var bankEntry = new BankEntryModel();
        var expectedEntry = new BankEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedEntry);
        IBankEntriesRepository repository = new BankEntriesRepository(requestExecutor);

        var result = await repository.UpdateAsync(entryId, bankEntry);

        Assert.Same(expectedEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"bankboekingen/{entryId}", bankEntry);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToBankEntryEndpoint()
    {
        var entryId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        IBankEntriesRepository repository = new BankEntriesRepository(requestExecutor);

        var result = await repository.DeleteAsync(entryId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"bankboekingen/{entryId}");
    }
}
