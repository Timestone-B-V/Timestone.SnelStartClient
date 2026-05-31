using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the legal form configured for the administration.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum LegalFormModel
{
    /// <summary>
    /// No legal form is configured.
    /// </summary>
    NotSet,

    /// <summary>
    /// Sole proprietorship.
    /// </summary>
    Eenmanszaak,

    /// <summary>
    /// General partnership.
    /// </summary>
    Vof,

    /// <summary>
    /// Private limited company.
    /// </summary>
    Bv,

    /// <summary>
    /// Public limited company.
    /// </summary>
    Nv,

    /// <summary>
    /// Other legal form.
    /// </summary>
    Overige,
}
