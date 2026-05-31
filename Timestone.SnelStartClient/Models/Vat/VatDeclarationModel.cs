using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Models.Vat;

/// <summary>
/// Model of a VAT declaration.
/// </summary>
public class VatDeclarationModel : SnelStartResource
{
    public VatBookYearModel? Boekjaar { get; set; }

    public DateTimeOffset? BetalenVoor { get; set; }

    public DateTimeOffset? AangiftePeriodeBeginDatum { get; set; }

    public VatDeclarationPeriodModel? BtwAangiftePeriode { get; set; }

    public DateTimeOffset? DatumTijdBerekening { get; set; }

    public DateTimeOffset? DatumTijdVerzending { get; set; }

    public bool? IsSuppletie { get; set; }

    public bool? IsAangifteGeschat { get; set; }

    public decimal? BtwPercentageHoog { get; set; }

    public decimal? BtwPercentageLaag { get; set; }

    public decimal? BtwPercentageOverig { get; set; }

    public string? Betalingskenmerk { get; set; }

    public string? FoutBericht { get; set; }

    public VatDeclarationStatusModel? BtwAangifteStatus { get; set; }

    public string? BtwNummer { get; set; }

    public VatDeclarationSectionModel? Rubriek1A { get; set; }

    public VatDeclarationSectionModel? Rubriek1B { get; set; }

    public VatDeclarationSectionModel? Rubriek1C { get; set; }

    public VatDeclarationSectionModel? Rubriek1D { get; set; }

    public VatDeclarationSectionModel? Rubriek1E { get; set; }

    public VatDeclarationSectionModel? Rubriek2A { get; set; }

    public VatDeclarationSectionModel? Rubriek3A { get; set; }

    public VatDeclarationSectionModel? Rubriek3B { get; set; }

    public VatDeclarationSectionModel? Rubriek3C { get; set; }

    public VatDeclarationSectionModel? Rubriek4A { get; set; }

    public VatDeclarationSectionModel? Rubriek4B { get; set; }

    public VatDeclarationSectionModel? Rubriek5A { get; set; }

    public VatDeclarationSectionModel? Rubriek5B { get; set; }

    public VatDeclarationSectionModel? Rubriek5C { get; set; }

    public VatDeclarationSectionModel? Rubriek5D { get; set; }

    public VatDeclarationSectionModel? Rubriek5E { get; set; }

    public VatDeclarationSectionModel? Rubriek5F { get; set; }

    public VatDeclarationSectionModel? Rubriek5G { get; set; }
}
