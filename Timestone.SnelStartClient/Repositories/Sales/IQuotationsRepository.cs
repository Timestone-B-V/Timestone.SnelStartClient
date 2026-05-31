using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Repository for quotations.
/// </summary>
public interface IQuotationsRepository
{
    /// <summary>
    /// Gets all available quotations from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<QuotationModel>> ListAsync(QuotationQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a quotation by its identifier.
    /// </summary>
    Task<QuotationModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new quotation.
    /// </summary>
    Task<QuotationModel?> CreateAsync(QuotationModel quotation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing quotation.
    /// </summary>
    Task<QuotationModel?> UpdateAsync(Guid id, QuotationModel quotation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a quotation by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
