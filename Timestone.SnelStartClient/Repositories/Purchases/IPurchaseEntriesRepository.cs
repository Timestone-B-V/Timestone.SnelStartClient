using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Purchases;

/// <summary>
/// Repository for purchase entries.
/// </summary>
public interface IPurchaseEntriesRepository
{
    /// <summary>
    /// Gets a purchase entry by its identifier.
    /// </summary>
    Task<PurchaseEntryModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new purchase entry.
    /// </summary>
    Task<PurchaseEntryModel?> CreateAsync(PurchaseEntryModel purchaseEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing purchase entry.
    /// </summary>
    Task<PurchaseEntryModel?> UpdateAsync(Guid id, PurchaseEntryModel purchaseEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a purchase entry by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a purchase entry from an attachment.
    /// </summary>
    Task<CreateFromAttachmentStatusModel?> CreateFromAttachmentAsync(DynamicResponseModel payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the status of creating a purchase entry from an attachment.
    /// </summary>
    Task<CreateFromAttachmentStatusModel?> GetCreateFromAttachmentStatusAsync(string instanceId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Processes a UBL payload for purchase entries.
    /// </summary>
    Task<PurchaseEntryUblResponseModel?> PostUblAsync(DynamicResponseModel payload, CancellationToken cancellationToken = default);
}
