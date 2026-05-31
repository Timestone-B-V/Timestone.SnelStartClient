using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Purchases;

/// <summary>
/// Implementation of the repository for purchase entries.
/// </summary>
internal sealed class PurchaseEntriesRepository : SnelStartRepositoryBase, IPurchaseEntriesRepository
{
    /// <summary>
    /// Initializes a new repository for purchase entries.
    /// </summary>
    public PurchaseEntriesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<PurchaseEntryModel?> IPurchaseEntriesRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<PurchaseEntryModel>($"inkoopboekingen/{id}", cancellationToken: cancellationToken);

    Task<PurchaseEntryModel?> IPurchaseEntriesRepository.CreateAsync(PurchaseEntryModel purchaseEntry, CancellationToken cancellationToken)
        => PostAsync<PurchaseEntryModel>("inkoopboekingen", purchaseEntry, cancellationToken: cancellationToken);

    Task<PurchaseEntryModel?> IPurchaseEntriesRepository.UpdateAsync(Guid id, PurchaseEntryModel purchaseEntry, CancellationToken cancellationToken)
        => PutAsync<PurchaseEntryModel>($"inkoopboekingen/{id}", purchaseEntry, cancellationToken: cancellationToken);

    Task<bool> IPurchaseEntriesRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"inkoopboekingen/{id}", cancellationToken);

    Task<CreateFromAttachmentStatusModel?> IPurchaseEntriesRepository.CreateFromAttachmentAsync(DynamicResponseModel payload, CancellationToken cancellationToken)
        => PostAsync<CreateFromAttachmentStatusModel>("inkoopboekingen/CreateFromAttachment", payload, cancellationToken: cancellationToken);

    Task<CreateFromAttachmentStatusModel?> IPurchaseEntriesRepository.GetCreateFromAttachmentStatusAsync(string instanceId, CancellationToken cancellationToken)
        => GetAsync<CreateFromAttachmentStatusModel>("inkoopboekingen/GetCreateFromAttachmentStatus", new AttachmentStatusQueryOptions { InstanceId = instanceId }, cancellationToken);

    Task<PurchaseEntryUblResponseModel?> IPurchaseEntriesRepository.PostUblAsync(DynamicResponseModel payload, CancellationToken cancellationToken)
        => PostAsync<PurchaseEntryUblResponseModel>("inkoopboekingen/ubl", payload, cancellationToken: cancellationToken);
}