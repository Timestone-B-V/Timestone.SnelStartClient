using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Query options for retrieving a user's access rights to an administration.
/// </summary>
public sealed class AuthorizationQueryOptions
{
    /// <summary>
    /// The identifier of the user.
    /// </summary>
    [QueryName("userIdentifier")]
    public Guid UserIdentifier { get; set; }
}