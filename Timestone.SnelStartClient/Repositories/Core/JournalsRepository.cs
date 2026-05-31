using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for journals.
/// </summary>
internal sealed class JournalsRepository : SnelStartRepositoryBase, IJournalsRepository
{
    /// <summary>
    /// Initializes a new repository for journals.
    /// </summary>
    public JournalsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<JournalModel>> IJournalsRepository.ListAsync(CancellationToken cancellationToken)
        => GetListAsync<JournalModel>("dagboeken", cancellationToken: cancellationToken);
}