using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Result of an authorization check.
/// </summary>
public class AuthorizationResultModel : DynamicResponseModel
{
    public bool? HasAccess { get; set; }
}
