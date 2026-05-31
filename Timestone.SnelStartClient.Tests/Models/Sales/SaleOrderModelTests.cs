using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Sales;

namespace Timestone.SnelStartClient.Tests.Models.Sales;

/// <summary>
/// Tests for sales-order related enum serialization.
/// </summary>
public class SaleOrderModelTests
{
    [Fact]
    public void DeserializeSaleOrderEnums_ShouldParseExpectedValues()
    {
        var json = """
                   {
                     "procesStatus": "Pakbon",
                     "verkooporderBtwIngaveModel": "Exclusief",
                     "verkoopOrderStatus": "Uitgevoerd"
                   }
                   """;

        var model = JsonConvert.DeserializeObject<SaleOrderModel>(json);

        Assert.NotNull(model);
        Assert.Equal(SaleOrderProcessStatusModel.Pakbon, model.ProcesStatus);
        Assert.Equal(SaleOrderVatEntryModeModel.Exclusief, model.VerkooporderBtwIngaveModel);
        Assert.Equal(SaleOrderStatusModel.Uitgevoerd, model.VerkoopOrderStatus);
    }

    [Fact]
    public void SerializeQuotationEnums_ShouldWriteExpectedStrings()
    {
        var model = new QuotationModel
        {
            ProcesStatus = SaleOrderProcessStatusModel.Offerte,
            VerkooporderBtwIngaveModel = SaleOrderVatEntryModeModel.Inclusief,
        };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal("Offerte", result[nameof(QuotationModel.ProcesStatus)]?.Value<string>());
        Assert.Equal("Inclusief", result[nameof(QuotationModel.VerkooporderBtwIngaveModel)]?.Value<string>());
    }

    [Fact]
    public void SerializeProcessStatusUpdate_ShouldWriteExpectedString()
    {
        var model = new SaleOrderProcessStatusUpdateModel
        {
            ProcesStatus = SaleOrderProcessStatusModel.Bevestiging,
        };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal("Bevestiging", result[nameof(SaleOrderProcessStatusUpdateModel.ProcesStatus)]?.Value<string>());
    }
}
