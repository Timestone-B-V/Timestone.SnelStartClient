using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Banking;

/// <summary>
/// Implementation of the repository for bank entries.
/// </summary>
internal sealed class BankEntriesRepository : SnelStartRepositoryBase, IBankEntriesRepository
{
    /// <summary>
    /// Initializes a new repository for bank entries.
    /// </summary>
    public BankEntriesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<BankEntryModel>> IBankEntriesRepository.ListAsync(BankEntryQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<BankEntryModel>("bankboekingen", queryOptions, cancellationToken);

    Task<BankEntryModel?> IBankEntriesRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<BankEntryModel>($"bankboekingen/{id}", cancellationToken: cancellationToken);

    Task<BankEntryModel?> IBankEntriesRepository.CreateAsync(BankEntryModel bankEntry, CancellationToken cancellationToken)
        => PostAsync<BankEntryModel>("bankboekingen", bankEntry, cancellationToken: cancellationToken);

    Task<BankEntryModel?> IBankEntriesRepository.UpdateAsync(Guid id, BankEntryModel bankEntry, CancellationToken cancellationToken)
        => PutAsync<BankEntryModel>($"bankboekingen/{id}", bankEntry, cancellationToken: cancellationToken);

    Task<bool> IBankEntriesRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"bankboekingen/{id}", cancellationToken);
}