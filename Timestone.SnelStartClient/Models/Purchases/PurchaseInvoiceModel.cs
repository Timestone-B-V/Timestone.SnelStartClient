using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Purchases;

/// <summary>
/// Model of a purchase invoice.
/// </summary>
public class PurchaseInvoiceModel : SnelStartResource
{
    public DateTimeOffset? ModifiedOn { get; set; }

    public decimal? OpenstaandSaldo { get; set; }

    public string? Factuurnummer { get; set; }

    public DateTimeOffset? VervalDatum { get; set; }

    public SnelStartReference? Relatie { get; set; }

    public DateTimeOffset? FactuurDatum { get; set; }

    public decimal? FactuurBedrag { get; set; }

    public SnelStartReference? InkoopBoeking { get; set; }
}
