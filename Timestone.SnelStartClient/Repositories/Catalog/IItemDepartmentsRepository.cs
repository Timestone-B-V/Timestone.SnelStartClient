using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Catalog;

/// <summary>
/// Repository for item departments.
/// </summary>
public interface IItemDepartmentsRepository
{
    /// <summary>
    /// Gets all available item departments from an administration.
    /// </summary>
    Task<IReadOnlyList<ItemDepartmentModel>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an item department by its identifier.
    /// </summary>
    Task<ItemDepartmentModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
