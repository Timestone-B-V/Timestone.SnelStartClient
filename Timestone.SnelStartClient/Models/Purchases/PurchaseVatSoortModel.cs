using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Timestone.SnelStartClient.Models.Purchases;

/// <summary>
/// Represents the VAT type to which a purchase VAT amount is booked.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PurchaseVatSoortModel
{
    Geen,
    VerkopenLaag,
    VerkopenHoog,
    VerkopenOverig,
    InkopenLaag,
    InkopenHoog,
    InkopenOverig,
    InkopenVerlegd,
}
