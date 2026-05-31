using System.Linq.Expressions;

namespace Timestone.SnelStartClient.Queries;

internal static class ODataOrderByExpressionBuilder
{
    internal static string Build(IEnumerable<(LambdaExpression Expression, bool Descending)> orderings)
    {
        ArgumentNullException.ThrowIfNull(orderings);

        var segments = orderings
            .Select(ordering => ordering.Descending
                ? $"{ODataPropertyPathBuilder.Build(ordering.Expression)} desc"
                : ODataPropertyPathBuilder.Build(ordering.Expression))
            .ToArray();

        if (segments.Length == 0)
        {
            throw new ArgumentException("At least one property must be specified for $orderby.", nameof(orderings));
        }

        return string.Join(',', segments);
    }
}
