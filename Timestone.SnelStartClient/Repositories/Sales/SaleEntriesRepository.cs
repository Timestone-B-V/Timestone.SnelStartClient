using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Implementation of the repository for sales entries.
/// </summary>
internal sealed class SaleEntriesRepository : SnelStartRepositoryBase, ISaleEntriesRepository
{
    /// <summary>
    /// Initializes a new repository for sales entries.
    /// </summary>
    public SaleEntriesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<SaleEntryModel?> ISaleEntriesRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<SaleEntryModel>($"verkoopboekingen/{id}", cancellationToken: cancellationToken);

    Task<SaleEntryModel?> ISaleEntriesRepository.CreateAsync(SaleEntryModel saleEntry, CancellationToken cancellationToken)
        => PostAsync<SaleEntryModel>("verkoopboekingen", saleEntry, cancellationToken: cancellationToken);

    Task<SaleEntryModel?> ISaleEntriesRepository.UpdateAsync(Guid id, SaleEntryModel saleEntry, CancellationToken cancellationToken)
        => PutAsync<SaleEntryModel>($"verkoopboekingen/{id}", saleEntry, cancellationToken: cancellationToken);

    Task<bool> ISaleEntriesRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"verkoopboekingen/{id}", cancellationToken);
}