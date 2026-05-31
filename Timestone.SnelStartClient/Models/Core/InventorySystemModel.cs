using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents the inventory valuation system.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum InventorySystemModel
{
    /// <summary>
    /// First in, first out.
    /// </summary>
    Fifo,

    /// <summary>
    /// Last in, first out.
    /// </summary>
    Lifo,
}
