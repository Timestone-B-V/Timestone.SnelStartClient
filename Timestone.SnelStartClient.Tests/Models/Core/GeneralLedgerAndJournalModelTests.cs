using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Models.Vat;

namespace Timestone.SnelStartClient.Tests.Models.Core;

/// <summary>
/// Tests for general ledger and journal enum serialization.
/// </summary>
public class GeneralLedgerAndJournalModelTests
{
    [Fact]
    public void DeserializeGeneralLedgerEnums_ShouldParseExpectedValues()
    {
        var json = """
                   {
                     "rekeningCode": "WinstEnVerlies",
                     "grootboekfunctie": "DagboekBank",
                     "btwSoort": ["Geen", "Laag"]
                   }
                   """;

        var model = JsonConvert.DeserializeObject<GeneralLedgerModel>(json);

        Assert.NotNull(model);
        Assert.Equal(GeneralLedgerAccountTypeModel.WinstEnVerlies, model.RekeningCode);
        Assert.Equal(GeneralLedgerFunctionModel.DagboekBank, model.Grootboekfunctie);
        Assert.Equal([BtwSoortModel.Geen, BtwSoortModel.Laag], model.BtwSoort);
    }

    [Fact]
    public void SerializeJournalType_ShouldWriteExpectedString()
    {
        var model = new JournalModel { Soort = JournalTypeModel.Memoriaal };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal("Memoriaal", result[nameof(JournalModel.Soort)]?.Value<string>());
    }
}
