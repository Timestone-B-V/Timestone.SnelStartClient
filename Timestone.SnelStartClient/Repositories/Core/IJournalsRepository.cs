using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for journals.
/// </summary>
public interface IJournalsRepository
{
    /// <summary>
    /// Gets all available journals.
    /// </summary>
    Task<IReadOnlyList<JournalModel>> ListAsync(CancellationToken cancellationToken = default);
}
