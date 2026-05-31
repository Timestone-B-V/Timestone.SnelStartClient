using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Implementation of the repository for sales orders.
/// </summary>
internal sealed class SaleOrdersRepository : SnelStartRepositoryBase, ISaleOrdersRepository
{
    /// <summary>
    /// Initializes a new repository for sales orders.
    /// </summary>
    public SaleOrdersRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<SaleOrderModel>> ISaleOrdersRepository.ListAsync(SaleOrderQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<SaleOrderModel>("verkooporders", queryOptions, cancellationToken);

    Task<SaleOrderModel?> ISaleOrdersRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<SaleOrderModel>($"verkooporders/{id}", cancellationToken: cancellationToken);

    Task<SaleOrderModel?> ISaleOrdersRepository.CreateAsync(SaleOrderModel saleOrder, CancellationToken cancellationToken)
        => PostAsync<SaleOrderModel>("verkooporders", saleOrder, cancellationToken: cancellationToken);

    Task<SaleOrderModel?> ISaleOrdersRepository.UpdateAsync(Guid id, SaleOrderModel saleOrder, CancellationToken cancellationToken)
        => PutAsync<SaleOrderModel>($"verkooporders/{id}", saleOrder, cancellationToken: cancellationToken);

    Task<bool> ISaleOrdersRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"verkooporders/{id}", cancellationToken);

    Task<SaleOrderModel?> ISaleOrdersRepository.UpdateProcessStatusAsync(Guid id, SaleOrderProcessStatusUpdateModel payload, CancellationToken cancellationToken)
        => PutAsync<SaleOrderModel>($"verkooporders/{id}/ProcesStatus", payload, cancellationToken: cancellationToken);
}