using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for countries.
/// </summary>
internal sealed class CountriesRepository : SnelStartRepositoryBase, ICountriesRepository
{
    /// <summary>
    /// Initializes a new repository for countries.
    /// </summary>
    public CountriesRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<CountryModel>> ICountriesRepository.ListAsync(CancellationToken cancellationToken)
        => GetListAsync<CountryModel>("landen", cancellationToken: cancellationToken);

    Task<CountryModel?> ICountriesRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<CountryModel>($"landen/{id}", cancellationToken: cancellationToken);
}