using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Vat;

namespace Timestone.SnelStartClient.Tests.Models.Vat;

/// <summary>
/// Tests for VAT-related enum serialization.
/// </summary>
public class VatModelEnumTests
{
    [Fact]
    public void DeserializeVatDeclarationEnums_ShouldParseExpectedValues()
    {
        var json = """
                   {
                     "btwAangiftePeriode": "Kwartaal",
                     "btwAangifteStatus": "GeaccepteerdExtern"
                   }
                   """;

        var model = JsonConvert.DeserializeObject<VatDeclarationModel>(json);

        Assert.NotNull(model);
        Assert.Equal(VatDeclarationPeriodModel.Kwartaal, model.BtwAangiftePeriode);
        Assert.Equal(VatDeclarationStatusModel.GeaccepteerdExtern, model.BtwAangifteStatus);
    }

    [Theory]
    [InlineData(BtwSoortModel.Geen, "Geen")]
    [InlineData(BtwSoortModel.Laag, "Laag")]
    [InlineData(BtwSoortModel.Hoog, "Hoog")]
    [InlineData(BtwSoortModel.Overig, "Overig")]
    public void SerializeVatRateBtwSoort_ShouldWriteExpectedString(BtwSoortModel value, string expectedJsonValue)
    {
        var model = new VatRateModel { BtwSoort = value };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal(expectedJsonValue, result[nameof(VatRateModel.BtwSoort)]?.Value<string>());
    }
}
