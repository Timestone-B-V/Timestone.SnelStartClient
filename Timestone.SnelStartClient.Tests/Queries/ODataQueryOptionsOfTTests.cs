using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Tests.Queries.TestModels;

namespace Timestone.SnelStartClient.Tests.Queries;

public sealed class ODataQueryOptionsOfTTests
{
    [Fact]
    public void SelectProperties_WhenCalled_SetsSelectClause()
    {
        var options = new ODataQueryOptions<FilterTestModel>()
            .SelectProperties(model => model.Name, model => model.Nested.Id);

        Assert.Equal("name,nested/id", options.Select);
    }

    [Fact]
    public void WhereAndWhereAndOrWhere_WhenCombined_BuildExpectedFilter()
    {
        var options = new ODataQueryOptions<FilterTestModel>()
            .Where(model => model.IsActive)
            .AndWhere(model => model.Name.StartsWith("A"))
            .OrWhere(model => model.Name.EndsWith("Z"));

        Assert.Equal("((isActive eq true) and (startswith(name,'A'))) or (endswith(name,'Z'))", options.Filter);
    }

    [Fact]
    public void OrderByAndThenByDescending_WhenCombined_BuildExpectedOrderByExpression()
    {
        var options = new ODataQueryOptions<FilterTestModel>()
            .OrderBy(model => model.Name)
            .ThenByDescending(model => model.CreatedOn);

        Assert.Equal("name,createdOn desc", options.OrderByExpression);
    }

    [Fact]
    public void OrWhere_WhenNoExistingFilterIsPresent_SetsFilter()
    {
        var options = new ODataQueryOptions<FilterTestModel>()
            .OrWhere(model => model.IsActive);

        Assert.Equal("isActive eq true", options.Filter);
    }

    [Fact]
    public void OrderByDescending_WhenCalled_SetsDescendingOrderByExpression()
    {
        var options = new ODataQueryOptions<FilterTestModel>()
            .OrderByDescending(model => model.CreatedOn);

        Assert.Equal("createdOn desc", options.OrderByExpression);
    }

    [Fact]
    public void OrderByDescending_WhenCalledAfterExistingOrdering_ReplacesPreviousOrdering()
    {
        var options = new ODataQueryOptions<FilterTestModel>()
            .OrderBy(model => model.Name)
            .ThenBy(model => model.CreatedOn)
            .OrderByDescending(model => model.Status);

        Assert.Equal("status desc", options.OrderByExpression);
    }
}
