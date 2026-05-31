using System.Globalization;
using System.Linq.Expressions;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Tests.Queries.TestModels;

namespace Timestone.SnelStartClient.Tests.Queries;

public sealed class ODataFilterExpressionBuilderTests
{
    [Fact]
    public void Build_WhenBooleanAndStringContainsAreUsed_ReturnsExpectedFilter()
    {
        Expression<Func<FilterTestModel, bool>> predicate = model => model.IsActive && model.Name.Contains("kabel");

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal("(isActive eq true and contains(name,'kabel'))", filter);
    }

    [Fact]
    public void Build_WhenNestedGuidComparisonIsUsed_ReturnsNestedPropertyPath()
    {
        var relationId = Guid.NewGuid();
        Expression<Func<FilterTestModel, bool>> predicate = model => model.Nested.Id == relationId;

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal($"nested/id eq {relationId}", filter);
    }

    [Fact]
    public void Build_WhenEnumAndDateComparisonAreUsed_FormatsBothLiteralsInvariantly()
    {
        var createdOn = new DateTimeOffset(2025, 03, 01, 10, 15, 30, TimeSpan.Zero);
        Expression<Func<FilterTestModel, bool>> predicate = model => model.Status == FilterStatus.Active && model.CreatedOn >= createdOn;

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal($"(status eq 'Active' and createdOn ge {createdOn.ToString("O", CultureInfo.InvariantCulture)})", filter);
    }

    [Fact]
    public void Build_WhenBooleanPropertyIsNegated_ReturnsFalseComparison()
    {
        Expression<Func<FilterTestModel, bool>> predicate = model => !model.IsActive;

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal("isActive eq false", filter);
    }

    [Fact]
    public void Build_WhenComplexExpressionIsNegated_WrapsOperandInNot()
    {
        Expression<Func<FilterTestModel, bool>> predicate = model => !(model.IsActive && model.Name.Contains("kabel"));

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal("not ((isActive eq true and contains(name,'kabel')))", filter);
    }

    [Fact]
    public void Build_WhenStringContainsQuote_EscapesQuoteInLiteral()
    {
        Expression<Func<FilterTestModel, bool>> predicate = model => model.Name == "O'Hara";

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal("name eq 'O''Hara'", filter);
    }

    [Fact]
    public void Build_WhenNullIsCompared_FormatsNullLiteral()
    {
        Expression<Func<FilterTestModel, bool>> predicate = model => model.Name == null;

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal("name eq null", filter);
    }

    [Fact]
    public void Build_WhenDateTimeComparisonIsUsed_FormatsDateTimeInvariantly()
    {
        var dueDate = new DateTime(2025, 04, 15, 12, 30, 45, DateTimeKind.Utc);
        Expression<Func<FilterTestModel, bool>> predicate = model => model.DueDate < dueDate;

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal($"dueDate lt {dueDate.ToString("O", CultureInfo.InvariantCulture)}", filter);
    }

    [Fact]
    public void Build_WhenDecimalComparisonIsUsed_FormatsDecimalInvariantly()
    {
        Expression<Func<FilterTestModel, bool>> predicate = model => model.Amount >= 12.5m;

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal("amount ge 12.5", filter);
    }

    [Fact]
    public void Build_WhenBooleanConstantIsUsed_ReturnsBooleanLiteral()
    {
        Expression<Func<FilterTestModel, bool>> predicate = _ => false;

        var filter = ODataFilterExpressionBuilder.Build(predicate);

        Assert.Equal("false", filter);
    }

    [Fact]
    public void Build_WhenUnsupportedMethodIsUsed_ThrowsNotSupportedException()
    {
        Expression<Func<FilterTestModel, bool>> predicate = model => string.IsNullOrEmpty(model.Name);

        var action = () => ODataFilterExpressionBuilder.Build(predicate);

        Assert.Throws<NotSupportedException>(action);
    }
}
