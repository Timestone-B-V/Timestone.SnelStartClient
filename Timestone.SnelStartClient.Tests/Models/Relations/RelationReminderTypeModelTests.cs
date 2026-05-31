using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Relations;

namespace Timestone.SnelStartClient.Tests.Models.Relations;

/// <summary>
/// Tests for relation reminder type enum serialization.
/// </summary>
public class RelationReminderTypeModelTests
{
    [Theory]
    [InlineData("Nee", ReminderTypeModel.Nee)]
    [InlineData("Onderneming", ReminderTypeModel.Onderneming)]
    [InlineData("Consument", ReminderTypeModel.Consument)]
    public void DeserializeAanmaningsoort_ShouldParseExpectedEnum(string jsonValue, ReminderTypeModel expectedValue)
    {
        var model = JsonConvert.DeserializeObject<RelationModel>($"{{\"aanmaningsoort\":\"{jsonValue}\"}}");

        Assert.NotNull(model);
        Assert.Equal(expectedValue, model.Aanmaningsoort);
    }

    [Fact]
    public void SerializeAanmaningsoort_ShouldWriteExpectedString()
    {
        var model = new RelationModel { Aanmaningsoort = ReminderTypeModel.Onderneming };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal("Onderneming", result[nameof(RelationModel.Aanmaningsoort)]?.Value<string>());
    }
}
