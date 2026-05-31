using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Common;

namespace Timestone.SnelStartClient.Tests.Models.Common;

/// <summary>
/// Tests for <see cref="CustomFieldDefinitionModel"/> enum serialization.
/// </summary>
public class CustomFieldDefinitionModelTests
{
    [Theory]
    [InlineData("Text", CustomFieldTypeModel.Text)]
    [InlineData("Integer", CustomFieldTypeModel.Integer)]
    [InlineData("Money", CustomFieldTypeModel.Money)]
    [InlineData("Float", CustomFieldTypeModel.Float)]
    [InlineData("DateTime", CustomFieldTypeModel.DateTime)]
    [InlineData("Boolean", CustomFieldTypeModel.Boolean)]
    [InlineData("Enum", CustomFieldTypeModel.Enum)]
    [InlineData("ByteArray", CustomFieldTypeModel.ByteArray)]
    public void DeserializeType_ShouldParseExpectedEnum(string jsonValue, CustomFieldTypeModel expectedValue)
    {
        var model = JsonConvert.DeserializeObject<CustomFieldDefinitionModel>($"{{\"type\":\"{jsonValue}\"}}");

        Assert.NotNull(model);
        Assert.Equal(expectedValue, model.Type);
    }

    [Theory]
    [InlineData(CustomFieldTypeModel.Text, "Text")]
    [InlineData(CustomFieldTypeModel.ByteArray, "ByteArray")]
    public void SerializeType_ShouldWriteExpectedString(CustomFieldTypeModel value, string expectedJsonValue)
    {
        var model = new CustomFieldDefinitionModel { Type = value };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal(expectedJsonValue, result[nameof(CustomFieldDefinitionModel.Type)]?.Value<string>());
    }
}
