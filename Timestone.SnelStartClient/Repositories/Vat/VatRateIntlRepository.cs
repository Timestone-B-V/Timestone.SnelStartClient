using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Vat;

/// <summary>
/// Implementation of the repository for international VAT rates.
/// </summary>
internal sealed class VatRateIntlRepository : SnelStartRepositoryBase, IVatRateIntlRepository
{
    /// <summary>
    /// Initializes a new repository for international VAT rates.
    /// </summary>
    public VatRateIntlRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<VatRateIntlModel>> IVatRateIntlRepository.ListAsync(VatRateIntlQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<VatRateIntlModel>("vatrates", queryOptions, cancellationToken);

    Task<VatRateIntlModel?> IVatRateIntlRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<VatRateIntlModel>($"vatrates/{id}", cancellationToken: cancellationToken);
}