using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Relations;

namespace Timestone.SnelStartClient.Tests.Models.Relations;

public sealed class RelationModelTests
{
    [Theory]
    [InlineData("Geen", IncassoSoortModel.Geen)]
    [InlineData("Core", IncassoSoortModel.Core)]
    [InlineData("B2B", IncassoSoortModel.B2B)]
    public void DeserializeObject_WhenIncassoSoortIsProvided_DeserializesExpectedEnumValue(string incassoSoort, IncassoSoortModel expectedValue)
    {
        var json = $"{{\"incassoSoort\":\"{incassoSoort}\"}}";

        var result = JsonConvert.DeserializeObject<RelationModel>(json);

        Assert.NotNull(result);
        Assert.Equal(expectedValue, result.IncassoSoort);
    }

    [Theory]
    [InlineData(IncassoSoortModel.Geen, "Geen")]
    [InlineData(IncassoSoortModel.Core, "Core")]
    [InlineData(IncassoSoortModel.B2B, "B2B")]
    public void SerializeObject_WhenIncassoSoortIsProvided_SerializesExpectedStringValue(IncassoSoortModel incassoSoort, string expectedValue)
    {
        var model = new RelationModel
        {
            IncassoSoort = incassoSoort
        };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal(expectedValue, result[nameof(RelationModel.IncassoSoort)]?.Value<string>());
    }
}
