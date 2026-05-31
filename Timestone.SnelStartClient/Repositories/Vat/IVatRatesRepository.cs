using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Vat;

/// <summary>
/// Repository for VAT rates.
/// </summary>
public interface IVatRatesRepository
{
    /// <summary>
    /// Gets all available VAT rates.
    /// </summary>
    Task<IReadOnlyList<VatRateModel>> ListAsync(CancellationToken cancellationToken = default);
}
