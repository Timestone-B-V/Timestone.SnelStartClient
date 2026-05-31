using System.Linq.Expressions;
namespace Timestone.SnelStartClient.Queries;

internal static class ODataSelectExpressionBuilder
{
    internal static string Build<TModel>(IEnumerable<Expression<Func<TModel, object?>>> properties)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var selectedPaths = properties
            .Select(BuildPath)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        if (selectedPaths.Length == 0)
        {
            throw new ArgumentException("At least one property must be specified for $select.", nameof(properties));
        }

        return string.Join(',', selectedPaths);
    }

    private static string BuildPath(LambdaExpression expression)
        => ODataPropertyPathBuilder.Build(expression);
}
