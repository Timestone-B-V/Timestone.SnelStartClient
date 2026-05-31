using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Models.Common;

/// <summary>
/// Address model as used across multiple endpoints.
/// </summary>
public class AddressModel : SnelStartModel
{
    /// <summary>
    /// The contact person.
    /// </summary>
    public string? Contactpersoon { get; set; }

    /// <summary>
    /// The street.
    /// </summary>
    public string? Straat { get; set; }

    /// <summary>
    /// The postal code.
    /// </summary>
    public string? Postcode { get; set; }

    /// <summary>
    /// The city.
    /// </summary>
    public string? Plaats { get; set; }

    /// <summary>
    /// The country.
    /// </summary>
    public SnelStartReference? Land { get; set; }
}
