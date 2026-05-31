using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for journal entries.
/// </summary>
public interface IJournalEntriesRepository
{
    /// <summary>
    /// Gets a journal entry by its identifier.
    /// </summary>
    Task<JournalEntryModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new journal entry.
    /// </summary>
    Task<JournalEntryModel?> CreateAsync(JournalEntryModel journalEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing journal entry.
    /// </summary>
    Task<JournalEntryModel?> UpdateAsync(Guid id, JournalEntryModel journalEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a journal entry by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
