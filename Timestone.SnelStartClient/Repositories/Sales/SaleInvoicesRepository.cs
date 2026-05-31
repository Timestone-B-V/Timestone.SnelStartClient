using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Implementation of the repository for sales invoices.
/// </summary>
internal sealed class SaleInvoicesRepository : SnelStartRepositoryBase, ISaleInvoicesRepository
{
    /// <summary>
    /// Initializes a new repository for sales invoices.
    /// </summary>
    public SaleInvoicesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<SaleInvoiceModel>> ISaleInvoicesRepository.ListAsync(SaleInvoiceQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<SaleInvoiceModel>("verkoopfacturen", queryOptions, cancellationToken);

    Task<SaleInvoiceModel?> ISaleInvoicesRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<SaleInvoiceModel>($"verkoopfacturen/{id}", cancellationToken: cancellationToken);

    Task<SaleInvoiceUblModel?> ISaleInvoicesRepository.GetUblAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<SaleInvoiceUblModel>($"verkoopfacturen/{id}/ubl", cancellationToken: cancellationToken);
}