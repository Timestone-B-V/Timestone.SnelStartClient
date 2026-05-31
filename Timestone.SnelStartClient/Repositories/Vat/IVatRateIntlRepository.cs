using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Vat;

/// <summary>
/// Repository for international VAT rates.
/// </summary>
public interface IVatRateIntlRepository
{
    /// <summary>
    /// Gets all available international VAT rates from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<VatRateIntlModel>> ListAsync(VatRateIntlQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an international VAT rate by its identifier.
    /// </summary>
    Task<VatRateIntlModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
