using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Vat;

/// <summary>
/// Repository for VAT rate definitions.
/// </summary>
public interface IVatRateDefinitionsRepository
{
    /// <summary>
    /// Gets all available VAT rate definitions from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<VatRateDefinitionModel>> ListAsync(VatRateDefinitionQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);
}
