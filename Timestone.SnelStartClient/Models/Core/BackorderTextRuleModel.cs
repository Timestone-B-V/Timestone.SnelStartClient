using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents how text lines are copied to a backorder.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum BackorderTextRuleModel
{
    /// <summary>
    /// Do not copy text lines.
    /// </summary>
    Geen,

    /// <summary>
    /// Copy text lines above the article.
    /// </summary>
    BovenArtikel,

    /// <summary>
    /// Copy text lines below the article.
    /// </summary>
    OnderArtikel,

    /// <summary>
    /// Copy all text lines.
    /// </summary>
    Alle,
}
