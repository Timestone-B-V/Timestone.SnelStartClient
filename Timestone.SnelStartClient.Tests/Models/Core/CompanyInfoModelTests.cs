using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Core;

namespace Timestone.SnelStartClient.Tests.Models.Core;

/// <summary>
/// Tests for <see cref="CompanyInfoModel"/> enum serialization.
/// </summary>
public class CompanyInfoModelTests
{
    [Fact]
    public void DeserializeEnums_ShouldParseExpectedValues()
    {
        var json = """
                   {
                     "rechtsvorm": "Bv",
                     "btwAangiftePeriodeSoort": "Kwartaal",
                     "icpAangiftePeriodeSoort": "Jaar",
                     "markeergedragInlezenBankafschriften": "Altijd",
                     "tekstregelsOvernemenNaarBackorder": "Alle",
                     "regelkortingVerkooporder": "BerekenenOverStukprijs",
                     "artikelcodeSoort": "Alfanumeriek",
                     "verkooporderVoorraadVanafNiveau": "Werkbon",
                     "voorraadSysteem": "Lifo",
                     "momentVoorraadBijwerken": "BijBoekenInkoopfactuur"
                   }
                   """;

        var model = JsonConvert.DeserializeObject<CompanyInfoModel>(json);

        Assert.NotNull(model);
        Assert.Equal(LegalFormModel.Bv, model.Rechtsvorm);
        Assert.Equal(CompanyVatPeriodTypeModel.Kwartaal, model.BtwAangiftePeriodeSoort);
        Assert.Equal(CompanyVatPeriodTypeModel.Jaar, model.IcpAangiftePeriodeSoort);
        Assert.Equal(BankStatementImportMarkingBehaviorModel.Altijd, model.MarkeergedragInlezenBankafschriften);
        Assert.Equal(BackorderTextRuleModel.Alle, model.TekstregelsOvernemenNaarBackorder);
        Assert.Equal(SaleOrderDiscountCalculationModel.BerekenenOverStukprijs, model.RegelkortingVerkooporder);
        Assert.Equal(ArticleCodeTypeModel.Alfanumeriek, model.ArtikelcodeSoort);
        Assert.Equal(SaleOrderStockLevelModel.Werkbon, model.VerkooporderVoorraadVanafNiveau);
        Assert.Equal(InventorySystemModel.Lifo, model.VoorraadSysteem);
        Assert.Equal(InventoryUpdateMomentModel.BijBoekenInkoopfactuur, model.MomentVoorraadBijwerken);
    }

    [Fact]
    public void SerializeEnums_ShouldWriteExpectedStrings()
    {
        var model = new CompanyInfoModel
        {
            Rechtsvorm = LegalFormModel.Eenmanszaak,
            BtwAangiftePeriodeSoort = CompanyVatPeriodTypeModel.Maand,
            IcpAangiftePeriodeSoort = CompanyVatPeriodTypeModel.Kwartaal,
            MarkeergedragInlezenBankafschriften = BankStatementImportMarkingBehaviorModel.AlleenBelangrijkste,
            TekstregelsOvernemenNaarBackorder = BackorderTextRuleModel.BovenArtikel,
            RegelkortingVerkooporder = SaleOrderDiscountCalculationModel.BerekenenOverRegelBedrag,
            ArtikelcodeSoort = ArticleCodeTypeModel.Numeriek,
            VerkooporderVoorraadVanafNiveau = SaleOrderStockLevelModel.PakbonEnAfhaalbon,
            VoorraadSysteem = InventorySystemModel.Fifo,
            MomentVoorraadBijwerken = InventoryUpdateMomentModel.BijBoekenOntvangst,
        };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal("Eenmanszaak", result[nameof(CompanyInfoModel.Rechtsvorm)]?.Value<string>());
        Assert.Equal("Maand", result[nameof(CompanyInfoModel.BtwAangiftePeriodeSoort)]?.Value<string>());
        Assert.Equal("Kwartaal", result[nameof(CompanyInfoModel.IcpAangiftePeriodeSoort)]?.Value<string>());
        Assert.Equal("AlleenBelangrijkste", result[nameof(CompanyInfoModel.MarkeergedragInlezenBankafschriften)]?.Value<string>());
        Assert.Equal("BovenArtikel", result[nameof(CompanyInfoModel.TekstregelsOvernemenNaarBackorder)]?.Value<string>());
        Assert.Equal("BerekenenOverRegelBedrag", result[nameof(CompanyInfoModel.RegelkortingVerkooporder)]?.Value<string>());
        Assert.Equal("Numeriek", result[nameof(CompanyInfoModel.ArtikelcodeSoort)]?.Value<string>());
        Assert.Equal("PakbonEnAfhaalbon", result[nameof(CompanyInfoModel.VerkooporderVoorraadVanafNiveau)]?.Value<string>());
        Assert.Equal("Fifo", result[nameof(CompanyInfoModel.VoorraadSysteem)]?.Value<string>());
        Assert.Equal("BijBoekenOntvangst", result[nameof(CompanyInfoModel.MomentVoorraadBijwerken)]?.Value<string>());
    }
}
