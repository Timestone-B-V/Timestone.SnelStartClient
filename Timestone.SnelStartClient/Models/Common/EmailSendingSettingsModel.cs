using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// Settings for sending emails.
/// </summary>
public class EmailSendingSettingsModel : SnelStartModel
{
    /// <summary>
    /// Indicates whether the email should be sent.
    /// </summary>
    public bool? ShouldSend { get; set; }

    /// <summary>
    /// The primary email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The CC email address.
    /// </summary>
    public string? CcEmail { get; set; }
}
