using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for cost centres.
/// </summary>
public interface ICostCentresRepository
{
    /// <summary>
    /// Gets all available cost centres.
    /// </summary>
    Task<IReadOnlyList<CostCentreModel>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a cost centre by its identifier.
    /// </summary>
    Task<CostCentreModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new cost centre.
    /// </summary>
    Task<CostCentreModel?> CreateAsync(CostCentreModel costCentre, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing cost centre.
    /// </summary>
    Task<CostCentreModel?> UpdateAsync(Guid id, CostCentreModel costCentre, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an active cost centre by its identifier.
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
