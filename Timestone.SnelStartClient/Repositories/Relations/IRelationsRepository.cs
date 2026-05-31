using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Models.Relations;
using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Relations;

/// <summary>
/// Repository for relations.
/// </summary>
public interface IRelationsRepository
{
    /// <summary>
    /// Gets all available relations from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<RelationModel>> ListAsync(RelationQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a relation by its identifier.
    /// </summary>
    Task<RelationModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new relation.
    /// </summary>
    Task<RelationModel?> CreateAsync(RelationModel relation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing relation.
    /// </summary>
    Task<RelationModel?> UpdateAsync(Guid id, RelationModel relation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a relation by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all available custom fields for a relation.
    /// </summary>
    Task<RelationCustomFieldsModel?> GetCustomFieldsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the custom fields of an existing relation.
    /// </summary>
    Task<RelationCustomFieldsModel?> UpdateCustomFieldsAsync(Guid id, UpdatedRelationCustomFieldsModel customFields, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets recurring direct debit authorizations for a relation.
    /// </summary>
    Task<IReadOnlyList<ContinuousDirectDebitAuthorizationModel>> GetContinuousDirectDebitAuthorizationsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets purchase entries for a relation.
    /// </summary>
    Task<IReadOnlyList<PurchaseEntryModel>> GetPurchaseEntriesAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets sales entries for a relation.
    /// </summary>
    Task<IReadOnlyList<SaleEntryModel>> GetSaleEntriesAsync(Guid id, CancellationToken cancellationToken = default);
}
