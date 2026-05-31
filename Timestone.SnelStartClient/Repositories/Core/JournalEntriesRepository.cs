using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for journal entries.
/// </summary>
internal sealed class JournalEntriesRepository : SnelStartRepositoryBase, IJournalEntriesRepository
{
    /// <summary>
    /// Initializes a new repository for journal entries.
    /// </summary>
    public JournalEntriesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<JournalEntryModel?> IJournalEntriesRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<JournalEntryModel>($"memoriaalboekingen/{id}", cancellationToken: cancellationToken);

    Task<JournalEntryModel?> IJournalEntriesRepository.CreateAsync(JournalEntryModel journalEntry, CancellationToken cancellationToken)
        => PostAsync<JournalEntryModel>("memoriaalboekingen", journalEntry, cancellationToken: cancellationToken);

    Task<JournalEntryModel?> IJournalEntriesRepository.UpdateAsync(Guid id, JournalEntryModel journalEntry, CancellationToken cancellationToken)
        => PutAsync<JournalEntryModel>($"memoriaalboekingen/{id}", journalEntry, cancellationToken: cancellationToken);

    Task<bool> IJournalEntriesRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"memoriaalboekingen/{id}", cancellationToken);
}