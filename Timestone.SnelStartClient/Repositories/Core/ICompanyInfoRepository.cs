using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for company information.
/// </summary>
public interface ICompanyInfoRepository
{
    /// <summary>
    /// Gets company information from an administration.
    /// </summary>
    Task<CompanyInfoModel?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates company information.
    /// </summary>
    Task<CompanyInfoModel?> UpdateAsync(CompanyInfoModel companyInfo, CancellationToken cancellationToken = default);
}
