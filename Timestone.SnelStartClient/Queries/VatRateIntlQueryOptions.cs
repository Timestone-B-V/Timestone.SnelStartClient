using Timestone.SnelStartClient.Models.Vat;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// Typed OData query options for retrieving international VAT rates.
/// </summary>
public sealed class VatRateIntlQueryOptions : ODataQueryOptions<VatRateIntlModel>;