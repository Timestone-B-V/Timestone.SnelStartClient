using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Implementation of the repository for sales order templates.
/// </summary>
internal sealed class SaleOrderTemplatesRepository : SnelStartRepositoryBase, ISaleOrderTemplatesRepository
{
    /// <summary>
    /// Initializes a new repository for sales order templates.
    /// </summary>
    public SaleOrderTemplatesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<SaleOrderTemplateModel>> ISaleOrderTemplatesRepository.ListAsync(CancellationToken cancellationToken)
        => GetListAsync<SaleOrderTemplateModel>("verkoopordersjablonen", cancellationToken: cancellationToken);

    Task<SaleOrderTemplateModel?> ISaleOrderTemplatesRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<SaleOrderTemplateModel>($"verkoopordersjablonen/{id}", cancellationToken: cancellationToken);
}