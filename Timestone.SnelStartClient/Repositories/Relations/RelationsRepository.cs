using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Models.Relations;
using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Relations;

/// <summary>
/// Implementation of the repository for relations.
/// </summary>
internal sealed class RelationsRepository : SnelStartRepositoryBase, IRelationsRepository
{
    /// <summary>
    /// Initializes a new repository for relations.
    /// </summary>
    public RelationsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<RelationModel>> IRelationsRepository.ListAsync(RelationQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<RelationModel>("relaties", queryOptions, cancellationToken);

    Task<RelationModel?> IRelationsRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<RelationModel>($"relaties/{id}", cancellationToken: cancellationToken);

    Task<RelationModel?> IRelationsRepository.CreateAsync(RelationModel relation, CancellationToken cancellationToken)
        => PostAsync<RelationModel>("relaties", relation, cancellationToken: cancellationToken);

    Task<RelationModel?> IRelationsRepository.UpdateAsync(Guid id, RelationModel relation, CancellationToken cancellationToken)
        => PutAsync<RelationModel>($"relaties/{id}", relation, cancellationToken: cancellationToken);

    Task<bool> IRelationsRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"relaties/{id}", cancellationToken);

    Task<RelationCustomFieldsModel?> IRelationsRepository.GetCustomFieldsAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<RelationCustomFieldsModel>($"relaties/{id}/customFields", cancellationToken: cancellationToken);

    Task<RelationCustomFieldsModel?> IRelationsRepository.UpdateCustomFieldsAsync(Guid id, UpdatedRelationCustomFieldsModel customFields, CancellationToken cancellationToken)
        => PutAsync<RelationCustomFieldsModel>($"relaties/{id}/customFields", customFields, cancellationToken: cancellationToken);

    Task<IReadOnlyList<ContinuousDirectDebitAuthorizationModel>> IRelationsRepository.GetContinuousDirectDebitAuthorizationsAsync(Guid id, CancellationToken cancellationToken)
        => GetListAsync<ContinuousDirectDebitAuthorizationModel>($"relaties/{id}/doorlopendeincassomachtigingen", cancellationToken: cancellationToken);

    Task<IReadOnlyList<PurchaseEntryModel>> IRelationsRepository.GetPurchaseEntriesAsync(Guid id, CancellationToken cancellationToken)
        => GetListAsync<PurchaseEntryModel>($"relaties/{id}/inkoopboekingen", cancellationToken: cancellationToken);

    Task<IReadOnlyList<SaleEntryModel>> IRelationsRepository.GetSaleEntriesAsync(Guid id, CancellationToken cancellationToken)
        => GetListAsync<SaleEntryModel>($"relaties/{id}/verkoopboekingen", cancellationToken: cancellationToken);
}