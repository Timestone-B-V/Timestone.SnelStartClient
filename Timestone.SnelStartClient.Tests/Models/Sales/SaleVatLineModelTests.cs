using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Sales;

namespace Timestone.SnelStartClient.Tests.Models.Sales;

/// <summary>
/// Tests for <see cref="SaleVatLineModel"/>.
/// </summary>
public class SaleVatLineModelTests
{
    [Theory]
    [InlineData("Geen", SaleVatSoortModel.Geen)]
    [InlineData("VerkopenLaag", SaleVatSoortModel.VerkopenLaag)]
    [InlineData("VerkopenHoog", SaleVatSoortModel.VerkopenHoog)]
    [InlineData("VerkopenOverig", SaleVatSoortModel.VerkopenOverig)]
    [InlineData("VerkopenVerlegd", SaleVatSoortModel.VerkopenVerlegd)]
    [InlineData("InkopenLaag", SaleVatSoortModel.InkopenLaag)]
    [InlineData("InkopenHoog", SaleVatSoortModel.InkopenHoog)]
    [InlineData("InkopenOverig", SaleVatSoortModel.InkopenOverig)]
    public void Deserialize_ShouldParseBtwSoort(string jsonValue, SaleVatSoortModel expectedValue)
    {
        var json = $$"""
                     {
                       "btwSoort": "{{jsonValue}}",
                       "btwBedrag": 12.34
                     }
                     """;

        var model = JsonConvert.DeserializeObject<SaleVatLineModel>(json);

        Assert.NotNull(model);
        Assert.Equal(expectedValue, model.BtwSoort);
    }

    [Theory]
    [InlineData(SaleVatSoortModel.Geen, "Geen")]
    [InlineData(SaleVatSoortModel.VerkopenLaag, "VerkopenLaag")]
    [InlineData(SaleVatSoortModel.VerkopenHoog, "VerkopenHoog")]
    [InlineData(SaleVatSoortModel.VerkopenOverig, "VerkopenOverig")]
    [InlineData(SaleVatSoortModel.VerkopenVerlegd, "VerkopenVerlegd")]
    [InlineData(SaleVatSoortModel.InkopenLaag, "InkopenLaag")]
    [InlineData(SaleVatSoortModel.InkopenHoog, "InkopenHoog")]
    [InlineData(SaleVatSoortModel.InkopenOverig, "InkopenOverig")]
    public void Serialize_ShouldWriteBtwSoortAsString(SaleVatSoortModel value, string expectedJsonValue)
    {
        var model = new SaleVatLineModel
        {
            BtwSoort = value,
            BtwBedrag = 12.34m,
        };

        var json = JsonConvert.SerializeObject(model);
        var jsonObject = JObject.Parse(json);

        Assert.Equal(expectedJsonValue, jsonObject[nameof(SaleVatLineModel.BtwSoort)]?.Value<string>());
    }
}
