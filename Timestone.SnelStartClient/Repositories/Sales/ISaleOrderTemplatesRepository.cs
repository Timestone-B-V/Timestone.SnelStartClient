using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Repository for sales order templates.
/// </summary>
public interface ISaleOrderTemplatesRepository
{
    /// <summary>
    /// Gets all available sales order templates.
    /// </summary>
    Task<IReadOnlyList<SaleOrderTemplateModel>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a sales order template by its identifier.
    /// </summary>
    Task<SaleOrderTemplateModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
