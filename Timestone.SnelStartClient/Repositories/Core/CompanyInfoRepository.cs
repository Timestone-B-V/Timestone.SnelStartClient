using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for company information.
/// </summary>
internal sealed class CompanyInfoRepository : SnelStartRepositoryBase, ICompanyInfoRepository
{
    /// <summary>
    /// Initializes a new repository for company information.
    /// </summary>
    public CompanyInfoRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<CompanyInfoModel?> ICompanyInfoRepository.GetAsync(CancellationToken cancellationToken)
        => GetAsync<CompanyInfoModel>("companyInfo", cancellationToken: cancellationToken);

    Task<CompanyInfoModel?> ICompanyInfoRepository.UpdateAsync(CompanyInfoModel companyInfo, CancellationToken cancellationToken)
        => PutAsync<CompanyInfoModel>("companyInfo", companyInfo, cancellationToken: cancellationToken);
}