using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Banking;

/// <summary>
/// Implementation of the repository for bank statement files.
/// </summary>
internal sealed class BankStatementFilesRepository : SnelStartRepositoryBase, IBankStatementFilesRepository
{
    /// <summary>
    /// Initializes a new repository for bank statement files.
    /// </summary>
    public BankStatementFilesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    async Task<IReadOnlyList<BankStatementFileResponseModel>> IBankStatementFilesRepository.CreateAsync(IReadOnlyList<BankStatementFileModel> files, CancellationToken cancellationToken)
    {
        var result = await PostAsync<List<BankStatementFileResponseModel>>("bankafschriftbestanden", files, cancellationToken: cancellationToken).ConfigureAwait(false);
        return result ?? [];
    }
}