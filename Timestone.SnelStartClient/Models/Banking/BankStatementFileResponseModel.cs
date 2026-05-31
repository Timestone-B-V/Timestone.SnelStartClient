using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Banking;

/// <summary>
/// Response for submitting bank statement files.
/// </summary>
public class BankStatementFileResponseModel : SnelStartModel
{
    /// <summary>
    /// The file name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Any errors that occurred during processing.
    /// </summary>
    public IReadOnlyList<ApiErrorModel>? Errors { get; set; }

    /// <summary>
    /// Indicates whether processing succeeded.
    /// </summary>
    public bool? IsSuccess { get; set; }
}
