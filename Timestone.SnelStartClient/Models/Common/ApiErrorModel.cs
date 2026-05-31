using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// Error information from an API response.
/// </summary>
public class ApiErrorModel : SnelStartModel
{
    /// <summary>
    /// Gets or sets the API specific error code.
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets the human-readable error message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the error description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets optional details about the error.
    /// </summary>
    public IReadOnlyList<string>? Details { get; set; }
}
