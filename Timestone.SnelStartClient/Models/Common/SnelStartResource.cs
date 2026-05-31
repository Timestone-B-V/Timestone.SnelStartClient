using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// Base type for resource models with an identifier and URI.
/// </summary>
public abstract class SnelStartResource : SnelStartModel
{
    /// <summary>
    /// The identifier of the resource.
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// The URI of the resource.
    /// </summary>
    public string? Uri { get; set; }
}
