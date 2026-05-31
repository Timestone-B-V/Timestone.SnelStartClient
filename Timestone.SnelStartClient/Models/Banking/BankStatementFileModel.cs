using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Banking;

/// <summary>
/// File used for bank statement import.
/// </summary>
public class BankStatementFileModel : SnelStartModel
{
    /// <summary>
    /// The file name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The Base64-encoded contents of the file.
    /// </summary>
    public string? Base64EncodedContent { get; set; }
}
