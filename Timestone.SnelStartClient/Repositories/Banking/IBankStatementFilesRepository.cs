using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Banking;

/// <summary>
/// Repository for bank statement files.
/// </summary>
public interface IBankStatementFilesRepository
{
    /// <summary>
    /// Submits one or more bank statement files for processing.
    /// </summary>
    Task<IReadOnlyList<BankStatementFileResponseModel>> CreateAsync(IReadOnlyList<BankStatementFileModel> files, CancellationToken cancellationToken = default);
}
