using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Catalog;

/// <summary>
/// Repository for price agreements.
/// </summary>
public interface IPriceAgreementsRepository
{
    /// <summary>
    /// Gets all available price agreements.
    /// </summary>
    Task<IReadOnlyList<PriceAgreementModel>> ListAsync(PriceAgreementQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);
}
