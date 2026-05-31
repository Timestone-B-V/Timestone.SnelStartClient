using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Represents the VAT type to which a sales VAT amount is booked.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SaleVatSoortModel
{
    /// <summary>
    /// No VAT is applied.
    /// </summary>
    Geen,

    /// <summary>
    /// Sales VAT at the low rate.
    /// </summary>
    VerkopenLaag,

    /// <summary>
    /// Sales VAT at the high rate.
    /// </summary>
    VerkopenHoog,

    /// <summary>
    /// Other sales VAT.
    /// </summary>
    VerkopenOverig,

    /// <summary>
    /// Reverse-charged sales VAT.
    /// </summary>
    VerkopenVerlegd,

    /// <summary>
    /// Purchase VAT at the low rate.
    /// </summary>
    InkopenLaag,

    /// <summary>
    /// Purchase VAT at the high rate.
    /// </summary>
    InkopenHoog,

    /// <summary>
    /// Other purchase VAT.
    /// </summary>
    InkopenOverig,
}
