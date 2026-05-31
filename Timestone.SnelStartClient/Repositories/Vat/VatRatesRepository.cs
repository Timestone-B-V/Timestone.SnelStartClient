using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Vat;

/// <summary>
/// Implementation of the repository for VAT rates.
/// </summary>
internal sealed class VatRatesRepository : SnelStartRepositoryBase, IVatRatesRepository
{
    /// <summary>
    /// Initializes a new repository for VAT rates.
    /// </summary>
    public VatRatesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<VatRateModel>> IVatRatesRepository.ListAsync(CancellationToken cancellationToken)
        => GetListAsync<VatRateModel>("btwtarieven", cancellationToken: cancellationToken);
}