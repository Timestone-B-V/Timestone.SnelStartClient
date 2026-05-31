using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Banking;

/// <summary>
/// Repository for cash entries.
/// </summary>
public interface ICashEntriesRepository
{
    /// <summary>
    /// Gets all available cash entries from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<CashEntryModel>> ListAsync(CashEntryQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a cash entry by its identifier.
    /// </summary>
    Task<CashEntryModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new cash entry.
    /// </summary>
    Task<CashEntryModel?> CreateAsync(CashEntryModel cashEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing cash entry.
    /// </summary>
    Task<CashEntryModel?> UpdateAsync(Guid id, CashEntryModel cashEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an active cash entry by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
