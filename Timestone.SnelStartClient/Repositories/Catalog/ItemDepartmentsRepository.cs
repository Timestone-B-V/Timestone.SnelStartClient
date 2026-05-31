using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Catalog;

/// <summary>
/// Implementation of the repository for item departments.
/// </summary>
internal sealed class ItemDepartmentsRepository : SnelStartRepositoryBase, IItemDepartmentsRepository
{
    /// <summary>
    /// Initializes a new repository for item departments.
    /// </summary>
    public ItemDepartmentsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<ItemDepartmentModel>> IItemDepartmentsRepository.ListAsync(CancellationToken cancellationToken)
        => GetListAsync<ItemDepartmentModel>("artikelomzetgroepen", cancellationToken: cancellationToken);

    Task<ItemDepartmentModel?> IItemDepartmentsRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<ItemDepartmentModel>($"artikelomzetgroepen/{id}", cancellationToken: cancellationToken);
}