using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Vat;

/// <summary>
/// Implementation of the repository for VAT rate definitions.
/// </summary>
internal sealed class VatRateDefinitionsRepository : SnelStartRepositoryBase, IVatRateDefinitionsRepository
{
    /// <summary>
    /// Initializes a new repository for VAT rate definitions.
    /// </summary>
    public VatRateDefinitionsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<VatRateDefinitionModel>> IVatRateDefinitionsRepository.ListAsync(VatRateDefinitionQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<VatRateDefinitionModel>("vatratedefinitions", queryOptions, cancellationToken);
}