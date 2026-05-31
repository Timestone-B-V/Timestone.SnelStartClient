using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Models.Relations;

/// <summary>
/// Represents a relation in the administration.
/// </summary>
public class RelationModel : SnelStartResource
{
    /// <summary>
    /// The relation types.
    /// </summary>
    public IReadOnlyList<string>? Relatiesoort { get; set; }

    /// <summary>
    /// The modification date.
    /// </summary>
    public DateTimeOffset? ModifiedOn { get; set; }

    /// <summary>
    /// The relation code.
    /// </summary>
    public int? Relatiecode { get; set; }

    /// <summary>
    /// The name of the relation.
    /// </summary>
    public string? Naam { get; set; }

    /// <summary>
    /// The registered address.
    /// </summary>
    public AddressModel? VestigingsAdres { get; set; }

    /// <summary>
    /// The correspondence address.
    /// </summary>
    public AddressModel? CorrespondentieAdres { get; set; }

    /// <summary>
    /// The phone number.
    /// </summary>
    public string? Telefoon { get; set; }

    /// <summary>
    /// The mobile phone number.
    /// </summary>
    public string? MobieleTelefoon { get; set; }

    /// <summary>
    /// The fax number.
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// The email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The VAT number.
    /// </summary>
    public string? BtwNummer { get; set; }

    /// <summary>
    /// The invoice discount.
    /// </summary>
    public decimal? Factuurkorting { get; set; }

    /// <summary>
    /// The credit term.
    /// </summary>
    public int? Krediettermijn { get; set; }

    /// <summary>
    /// Indicates whether banking is enabled.
    /// </summary>
    public bool? Bankieren { get; set; }

    /// <summary>
    /// Indicates whether the relation is inactive.
    /// </summary>
    public bool? Nonactief { get; set; }

    /// <summary>
    /// The credit limit.
    /// </summary>
    public decimal? KredietLimiet { get; set; }

    /// <summary>
    /// The memo.
    /// </summary>
    public string? Memo { get; set; }

    /// <summary>
    /// The Chamber of Commerce number.
    /// </summary>
    public string? KvkNummer { get; set; }

    /// <summary>
    /// The OIN number.
    /// </summary>
    public string? Oin { get; set; }

    /// <summary>
    /// The website URL.
    /// </summary>
    public string? WebsiteUrl { get; set; }

    /// <summary>
    /// The reminder type.
    /// </summary>
    public ReminderTypeModel? Aanmaningsoort { get; set; }

    /// <summary>
    /// Settings for quotation emails.
    /// </summary>
    public EmailSendingSettingsModel? OfferteEmailVersturen { get; set; }

    /// <summary>
    /// Settings for confirmation emails.
    /// </summary>
    public EmailSendingSettingsModel? BevestigingsEmailVersturen { get; set; }

    /// <summary>
    /// Settings for invoice emails.
    /// </summary>
    public EmailSendingSettingsModel? FactuurEmailVersturen { get; set; }

    /// <summary>
    /// Settings for reminder emails.
    /// </summary>
    public EmailSendingSettingsModel? AanmaningEmailVersturen { get; set; }

    /// <summary>
    /// Settings for quotation request emails.
    /// </summary>
    public EmailSendingSettingsModel? OfferteAanvraagEmailVersturen { get; set; }

    /// <summary>
    /// Settings for order emails.
    /// </summary>
    public EmailSendingSettingsModel? BestellingEmailVersturen { get; set; }

    /// <summary>
    /// Indicates whether a UBL file is sent as an attachment.
    /// </summary>
    public bool? UblBestandAlsBijlage { get; set; }

    /// <summary>
    /// The IBAN.
    /// </summary>
    public string? Iban { get; set; }

    /// <summary>
    /// The BIC.
    /// </summary>
    public string? Bic { get; set; }

    /// <summary>
    /// The direct debit type.
    /// </summary>
    public IncassoSoortModel? IncassoSoort { get; set; }

    /// <summary>
    /// The invoice relation.
    /// </summary>
    public SnelStartReference? FactuurRelatie { get; set; }

    /// <summary>
    /// URI to the purchase entries of the relation.
    /// </summary>
    public string? InkoopBoekingenUri { get; set; }

    /// <summary>
    /// URI to the sales entries of the relation.
    /// </summary>
    public string? VerkoopBoekingenUri { get; set; }

    /// <summary>
    /// The linked documents.
    /// </summary>
    public IReadOnlyList<DocumentModel>? Documents { get; set; }

    /// <summary>
    /// The extra customer fields.
    /// </summary>
    public IReadOnlyList<ExtraFieldModel>? ExtraVeldenKlant { get; set; }
}
