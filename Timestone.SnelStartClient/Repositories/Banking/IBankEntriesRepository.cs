using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Banking;

/// <summary>
/// Repository for bank entries.
/// </summary>
public interface IBankEntriesRepository
{
    /// <summary>
    /// Gets all available bank entries from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<BankEntryModel>> ListAsync(BankEntryQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a bank entry by its identifier.
    /// </summary>
    Task<BankEntryModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new bank entry.
    /// </summary>
    Task<BankEntryModel?> CreateAsync(BankEntryModel bankEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing bank entry.
    /// </summary>
    Task<BankEntryModel?> UpdateAsync(Guid id, BankEntryModel bankEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an active bank entry by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
