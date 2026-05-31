using System.Linq.Expressions;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Tests.Queries.TestModels;

namespace Timestone.SnelStartClient.Tests.Queries;

public sealed class ODataOrderByExpressionBuilderTests
{
    [Fact]
    public void Build_WhenMultipleOrderingsAreProvided_ReturnsCombinedOrderByExpression()
    {
        var orderings = new (LambdaExpression Expression, bool Descending)[]
        {
            ((Expression<Func<FilterTestModel, object?>>)(model => model.Name), false),
            ((Expression<Func<FilterTestModel, object?>>)(model => model.Nested.Id), true)
        };

        var orderBy = ODataOrderByExpressionBuilder.Build(orderings);

        Assert.Equal("name,nested/id desc", orderBy);
    }

    [Fact]
    public void Build_WhenNoOrderingsAreProvided_ThrowsArgumentException()
    {
        var action = () => ODataOrderByExpressionBuilder.Build([]);

        Assert.Throws<ArgumentException>(action);
    }
}
