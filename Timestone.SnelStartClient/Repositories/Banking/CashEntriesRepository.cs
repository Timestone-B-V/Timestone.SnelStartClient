using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Banking;

/// <summary>
/// Implementation of the repository for cash entries.
/// </summary>
internal sealed class CashEntriesRepository : SnelStartRepositoryBase, ICashEntriesRepository
{
    /// <summary>
    /// Initializes a new repository for cash entries.
    /// </summary>
    public CashEntriesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<CashEntryModel>> ICashEntriesRepository.ListAsync(CashEntryQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<CashEntryModel>("kasboekingen", queryOptions, cancellationToken);

    Task<CashEntryModel?> ICashEntriesRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<CashEntryModel>($"kasboekingen/{id}", cancellationToken: cancellationToken);

    Task<CashEntryModel?> ICashEntriesRepository.CreateAsync(CashEntryModel cashEntry, CancellationToken cancellationToken)
        => PostAsync<CashEntryModel>("kasboekingen", cashEntry, cancellationToken: cancellationToken);

    Task<CashEntryModel?> ICashEntriesRepository.UpdateAsync(Guid id, CashEntryModel cashEntry, CancellationToken cancellationToken)
        => PutAsync<CashEntryModel>($"kasboekingen/{id}", cashEntry, cancellationToken: cancellationToken);

    Task<bool> ICashEntriesRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"kasboekingen/{id}", cancellationToken);
}