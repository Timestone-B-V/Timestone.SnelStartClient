using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for cost centres.
/// </summary>
internal sealed class CostCentresRepository : SnelStartRepositoryBase, ICostCentresRepository
{
    /// <summary>
    /// Initializes a new repository for cost centres.
    /// </summary>
    public CostCentresRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<CostCentreModel>> ICostCentresRepository.ListAsync(CancellationToken cancellationToken)
        => GetListAsync<CostCentreModel>("kostenplaatsen", cancellationToken: cancellationToken);

    Task<CostCentreModel?> ICostCentresRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<CostCentreModel>($"kostenplaatsen/{id}", cancellationToken: cancellationToken);

    Task<CostCentreModel?> ICostCentresRepository.CreateAsync(CostCentreModel costCentre, CancellationToken cancellationToken)
        => PostAsync<CostCentreModel>("kostenplaatsen", costCentre, cancellationToken: cancellationToken);

    Task<CostCentreModel?> ICostCentresRepository.UpdateAsync(Guid id, CostCentreModel costCentre, CancellationToken cancellationToken)
        => PutAsync<CostCentreModel>($"kostenplaatsen/{id}", costCentre, cancellationToken: cancellationToken);

    Task<bool> ICostCentresRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"kostenplaatsen/{id}", cancellationToken);
}