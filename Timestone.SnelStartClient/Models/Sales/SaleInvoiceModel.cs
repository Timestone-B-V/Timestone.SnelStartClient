using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Sales;

/// <summary>
/// Model of a sales invoice.
/// </summary>
public class SaleInvoiceModel : SnelStartResource
{
    public SnelStartReference? VerkoopBoeking { get; set; }

    public DateTimeOffset? ModifiedOn { get; set; }

    public decimal? OpenstaandSaldo { get; set; }

    public string? Factuurnummer { get; set; }

    public DateTimeOffset? VervalDatum { get; set; }

    public SnelStartReference? Relatie { get; set; }

    public DateTimeOffset? FactuurDatum { get; set; }

    public decimal? FactuurBedrag { get; set; }

    public IReadOnlyList<SnelStartReference>? VerkoopOrders { get; set; }
}
