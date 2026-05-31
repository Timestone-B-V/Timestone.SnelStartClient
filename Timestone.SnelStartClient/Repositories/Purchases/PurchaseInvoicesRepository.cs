using Timestone.SnelStartClient.Models.Purchases;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Purchases;

/// <summary>
/// Implementation of the repository for purchase invoices.
/// </summary>
internal sealed class PurchaseInvoicesRepository : SnelStartRepositoryBase, IPurchaseInvoicesRepository
{
    /// <summary>
    /// Initializes a new repository for purchase invoices.
    /// </summary>
    public PurchaseInvoicesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<PurchaseInvoiceModel>> IPurchaseInvoicesRepository.ListAsync(PurchaseInvoiceQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<PurchaseInvoiceModel>("inkoopfacturen", queryOptions, cancellationToken);
}