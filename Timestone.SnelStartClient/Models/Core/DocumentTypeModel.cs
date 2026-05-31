using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the supported document parent types for document endpoints.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum DocumentTypeModel
{
    /// <summary>
    /// Documents linked to purchase entries.
    /// </summary>
    Inkoopboekingen,

    /// <summary>
    /// Documents linked to sales entries.
    /// </summary>
    Verkoopboekingen,

    /// <summary>
    /// Documents linked to relations.
    /// </summary>
    Relaties,
}
