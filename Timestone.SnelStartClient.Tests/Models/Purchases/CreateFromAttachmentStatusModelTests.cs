using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timestone.SnelStartClient.Models.Purchases;

namespace Timestone.SnelStartClient.Tests.Models.Purchases;

/// <summary>
/// Tests for <see cref="CreateFromAttachmentStatusModel"/> enum serialization.
/// </summary>
public class CreateFromAttachmentStatusModelTests
{
    [Theory]
    [InlineData("Running", CreateFromAttachmentStateModel.Running)]
    [InlineData("Completed", CreateFromAttachmentStateModel.Completed)]
    [InlineData("ContinuedAsNew", CreateFromAttachmentStateModel.ContinuedAsNew)]
    [InlineData("Failed", CreateFromAttachmentStateModel.Failed)]
    [InlineData("Canceled", CreateFromAttachmentStateModel.Canceled)]
    [InlineData("Terminated", CreateFromAttachmentStateModel.Terminated)]
    [InlineData("Pending", CreateFromAttachmentStateModel.Pending)]
    [InlineData("NotFound", CreateFromAttachmentStateModel.NotFound)]
    [InlineData("Unknown", CreateFromAttachmentStateModel.Unknown)]
    public void DeserializeStatus_ShouldParseExpectedEnum(string jsonValue, CreateFromAttachmentStateModel expectedValue)
    {
        var model = JsonConvert.DeserializeObject<CreateFromAttachmentStatusModel>($"{{\"status\":\"{jsonValue}\"}}");

        Assert.NotNull(model);
        Assert.Equal(expectedValue, model.Status);
    }

    [Theory]
    [InlineData(CreateFromAttachmentStateModel.Completed, "Completed")]
    [InlineData(CreateFromAttachmentStateModel.NotFound, "NotFound")]
    public void SerializeStatus_ShouldWriteExpectedString(CreateFromAttachmentStateModel value, string expectedJsonValue)
    {
        var model = new CreateFromAttachmentStatusModel { Status = value };

        var json = JsonConvert.SerializeObject(model);
        var result = JObject.Parse(json);

        Assert.Equal(expectedJsonValue, result[nameof(CreateFromAttachmentStatusModel.Status)]?.Value<string>());
    }
}
