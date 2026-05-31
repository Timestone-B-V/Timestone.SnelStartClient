using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Catalog;

/// <summary>
/// Model of a price agreement.
/// </summary>
public class PriceAgreementModel : SnelStartResource
{
    /// <summary>
    /// The relation.
    /// </summary>
    public SnelStartReference? Relatie { get; set; }

    /// <summary>
    /// The article.
    /// </summary>
    public SnelStartReference? Artikel { get; set; }

    /// <summary>
    /// The reference date.
    /// </summary>
    public DateTimeOffset? Datum { get; set; }

    /// <summary>
    /// The quantity.
    /// </summary>
    public decimal? Aantal { get; set; }

    /// <summary>
    /// The discount.
    /// </summary>
    public decimal? Korting { get; set; }

    /// <summary>
    /// The sales price.
    /// </summary>
    public decimal? Verkoopprijs { get; set; }

    /// <summary>
    /// The base price.
    /// </summary>
    public decimal? Basisprijs { get; set; }

    /// <summary>
    /// The start date.
    /// </summary>
    public DateTimeOffset? DatumVanaf { get; set; }

    /// <summary>
    /// The end date.
    /// </summary>
    public DateTimeOffset? DatumTotEnMet { get; set; }

    /// <summary>
    /// The price determination type.
    /// </summary>
    public PriceAgreementDeterminationTypeModel? PrijsBepalingSoort { get; set; }
}
