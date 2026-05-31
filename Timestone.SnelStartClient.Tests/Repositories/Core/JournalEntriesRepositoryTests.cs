using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class JournalEntriesRepositoryTests
{
    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToJournalEntryEndpoint()
    {
        var journalEntryId = Guid.NewGuid();
        var expectedJournalEntry = new JournalEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedJournalEntry);
        IJournalEntriesRepository repository = new JournalEntriesRepository(requestExecutor);

        var result = await repository.GetAsync(journalEntryId);

        Assert.Same(expectedJournalEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"memoriaalboekingen/{journalEntryId}");
    }

    [Fact]
    public async Task CreateAsync_WhenJournalEntryIsProvided_ForwardsPostRequestToJournalEntriesEndpoint()
    {
        var journalEntry = new JournalEntryModel();
        var expectedJournalEntry = new JournalEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedJournalEntry);
        IJournalEntriesRepository repository = new JournalEntriesRepository(requestExecutor);

        var result = await repository.CreateAsync(journalEntry);

        Assert.Same(expectedJournalEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "memoriaalboekingen", journalEntry);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdentifierAndJournalEntryAreProvided_ForwardsPutRequestToJournalEntryEndpoint()
    {
        var journalEntryId = Guid.NewGuid();
        var journalEntry = new JournalEntryModel();
        var expectedJournalEntry = new JournalEntryModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedJournalEntry);
        IJournalEntriesRepository repository = new JournalEntriesRepository(requestExecutor);

        var result = await repository.UpdateAsync(journalEntryId, journalEntry);

        Assert.Same(expectedJournalEntry, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Put, $"memoriaalboekingen/{journalEntryId}", journalEntry);
    }

    [Fact]
    public async Task DeleteAsync_WhenIdentifierIsProvided_ForwardsDeleteRequestToJournalEntryEndpoint()
    {
        var journalEntryId = Guid.NewGuid();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        IJournalEntriesRepository repository = new JournalEntriesRepository(requestExecutor);

        var result = await repository.DeleteAsync(journalEntryId);

        Assert.True(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Delete, $"memoriaalboekingen/{journalEntryId}");
    }
}
