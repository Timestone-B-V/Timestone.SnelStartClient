using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Core;

/// <summary>
/// Represents when inventory is updated.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum InventoryUpdateMomentModel
{
    /// <summary>
    /// Update inventory when booking receipt.
    /// </summary>
    BijBoekenOntvangst,

    /// <summary>
    /// Update inventory when booking the purchase invoice.
    /// </summary>
    BijBoekenInkoopfactuur,
}
