using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// Base type for all SnelStart models.
/// </summary>
public abstract class SnelStartModel
{
    /// <summary>
    /// Unknown or not explicitly modeled properties from the API response.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JToken> AdditionalData { get; set; } = new Dictionary<string, JToken>(StringComparer.OrdinalIgnoreCase);
}
