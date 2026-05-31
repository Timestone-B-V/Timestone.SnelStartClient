using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Implementation of the repository for authorization checks.
/// </summary>
internal sealed class AuthorizationRepository : SnelStartRepositoryBase, IAuthorizationRepository
{
    /// <summary>
    /// Initializes a new repository for authorization checks.
    /// </summary>
    public AuthorizationRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<AuthorizationResultModel?> IAuthorizationRepository.HasUserAccessToAdministrationAsync(Guid userIdentifier, CancellationToken cancellationToken)
        => GetAsync<AuthorizationResultModel>("authorization/HasUserAccessToAdministration", new AuthorizationQueryOptions { UserIdentifier = userIdentifier }, cancellationToken);
}