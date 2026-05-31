using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Repository for sales entries.
/// </summary>
public interface ISaleEntriesRepository
{
    /// <summary>
    /// Gets a sales entry by its identifier.
    /// </summary>
    Task<SaleEntryModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new sales entry.
    /// </summary>
    Task<SaleEntryModel?> CreateAsync(SaleEntryModel saleEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing sales entry.
    /// </summary>
    Task<SaleEntryModel?> UpdateAsync(Guid id, SaleEntryModel saleEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a sales entry by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
