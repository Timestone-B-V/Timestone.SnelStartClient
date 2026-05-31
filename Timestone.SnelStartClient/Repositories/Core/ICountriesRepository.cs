using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for countries.
/// </summary>
public interface ICountriesRepository
{
    /// <summary>
    /// Gets all available countries.
    /// </summary>
    Task<IReadOnlyList<CountryModel>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a country by its identifier.
    /// </summary>
    Task<CountryModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
