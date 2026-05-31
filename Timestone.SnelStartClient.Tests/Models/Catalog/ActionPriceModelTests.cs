using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Catalog;

namespace Timestone.SnelStartClient.Tests.Models.Catalog;

/// <summary>
/// Tests for catalog price-related enum serialization.
/// </summary>
public class ActionPriceModelTests
{
    [Theory]
    [InlineData("Actief", PriceStatusModel.Actief)]
    [InlineData("Gepland", PriceStatusModel.Gepland)]
    [InlineData("Verlopen", PriceStatusModel.Verlopen)]
    public void DeserializeActionPriceStatus_ShouldParseExpectedEnum(string jsonValue, PriceStatusModel expectedValue)
    {
        var model = JsonConvert.DeserializeObject<ActionPriceModel>($"{{\"status\":\"{jsonValue}\"}}");

        Assert.NotNull(model);
        Assert.Equal(expectedValue, model.Status);
    }

    [Theory]
    [InlineData(PriceInputModel.Bedrag, "Bedrag")]
    [InlineData(PriceInputModel.StaffelBedrag, "StaffelBedrag")]
    [InlineData(PriceInputModel.Korting, "Korting")]
    [InlineData(PriceInputModel.StaffelKorting, "StaffelKorting")]
    public void SerializeActionPriceArticlePrijsIngave_ShouldWriteExpectedString(PriceInputModel value, string expectedJsonValue)
    {
        var model = new ActionPriceArticleModel { PrijsIngave = value };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal(expectedJsonValue, result[nameof(ActionPriceArticleModel.PrijsIngave)]?.Value<string>());
    }

    [Theory]
    [InlineData("NormaleVerkoopprijs", PriceAgreementDeterminationTypeModel.NormaleVerkoopprijs)]
    [InlineData("ActieprijzenPerArtikel", PriceAgreementDeterminationTypeModel.ActieprijzenPerArtikel)]
    [InlineData("ActieprijzenPerArtikelkortingsgroep", PriceAgreementDeterminationTypeModel.ActieprijzenPerArtikelkortingsgroep)]
    [InlineData("AfspraakPerArtikelklant", PriceAgreementDeterminationTypeModel.AfspraakPerArtikelklant)]
    [InlineData("AfspraakPerArtikelPerKlantkortingsgroep", PriceAgreementDeterminationTypeModel.AfspraakPerArtikelPerKlantkortingsgroep)]
    [InlineData("AfspraakPerKlantPerArtikelkortingsgroep", PriceAgreementDeterminationTypeModel.AfspraakPerKlantPerArtikelkortingsgroep)]
    [InlineData("AfspraakPerArtikelkortingsgroepPerKlantkortingsgroep", PriceAgreementDeterminationTypeModel.AfspraakPerArtikelkortingsgroepPerKlantkortingsgroep)]
    public void DeserializePriceAgreementDeterminationType_ShouldParseExpectedEnum(string jsonValue, PriceAgreementDeterminationTypeModel expectedValue)
    {
        var model = JsonConvert.DeserializeObject<PriceAgreementModel>($"{{\"prijsBepalingSoort\":\"{jsonValue}\"}}");

        Assert.NotNull(model);
        Assert.Equal(expectedValue, model.PrijsBepalingSoort);
    }
}
