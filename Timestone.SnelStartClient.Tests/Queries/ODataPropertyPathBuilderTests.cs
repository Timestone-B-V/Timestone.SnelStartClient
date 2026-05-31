using System.Linq.Expressions;
using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;

namespace Timestone.SnelStartClient.Tests.Queries;

public sealed class ODataPropertyPathBuilderTests
{
    [Fact]
    public void Build_WhenNestedPropertyExpressionIsProvided_ReturnsSlashSeparatedCamelCasePath()
    {
        Expression<Func<ArticleQueryModel, object?>> expression = article => article.Relatie!.Id;

        var path = ODataPropertyPathBuilder.Build(expression);

        Assert.Equal("relatie/id", path);
    }

    [Fact]
    public void Build_WhenExpressionIsNotDirectPropertyAccess_ThrowsNotSupportedException()
    {
        Expression<Func<ArticleQueryModel, object?>> expression = article => article.Omschrijving!.Trim();

        var action = () => ODataPropertyPathBuilder.Build(expression);

        Assert.Throws<NotSupportedException>(action);
    }

    [Fact]
    public void IsModelProperty_WhenExpressionTargetsModelProperty_ReturnsTrue()
    {
        Expression<Func<ArticleQueryModel, object?>> expression = article => article.Relatie!.Id;

        var isModelProperty = ODataPropertyPathBuilder.IsModelProperty(expression.Body);

        Assert.True(isModelProperty);
    }

    [Fact]
    public void IsModelProperty_WhenExpressionTargetsCapturedValue_ReturnsFalse()
    {
        var relationId = Guid.NewGuid();
        Expression<Func<Guid>> expression = () => relationId;

        var isModelProperty = ODataPropertyPathBuilder.IsModelProperty(expression.Body);

        Assert.False(isModelProperty);
    }
}
