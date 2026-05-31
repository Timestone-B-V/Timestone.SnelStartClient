using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Tests.Queries.TestModels;

namespace Timestone.SnelStartClient.Tests.Queries;

public sealed class ODataSelectExpressionBuilderTests
{
    [Fact]
    public void Build_WhenDuplicatePropertiesAreProvided_ReturnsDistinctSelectPaths()
    {
        var select = ODataSelectExpressionBuilder.Build<FilterTestModel>(
        [
            model => model.Name,
            model => model.Nested.Id,
            model => model.Name
        ]);

        Assert.Equal("name,nested/id", select);
    }

    [Fact]
    public void Build_WhenNoPropertiesAreProvided_ThrowsArgumentException()
    {
        var action = () => ODataSelectExpressionBuilder.Build<FilterTestModel>([]);

        Assert.Throws<ArgumentException>(action);
    }
}
