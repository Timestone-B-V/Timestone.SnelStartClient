using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Core;

/// <summary>
/// Repository for authorization checks.
/// </summary>
public interface IAuthorizationRepository
{
    /// <summary>
    /// Checks whether a user has access to an administration.
    /// </summary>
    Task<AuthorizationResultModel?> HasUserAccessToAdministrationAsync(Guid userIdentifier, CancellationToken cancellationToken = default);
}
