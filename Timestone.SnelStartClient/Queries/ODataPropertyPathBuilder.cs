using System.Linq.Expressions;
using Newtonsoft.Json.Serialization;

namespace Timestone.SnelStartClient.Queries;

internal static class ODataPropertyPathBuilder
{
    private static readonly CamelCaseNamingStrategy NamingStrategy = new();

    internal static string Build(LambdaExpression expression)
        => Build(expression.Body, expression.ToString());

    internal static string Build(Expression expression)
        => Build(expression, expression.ToString());

    private static string Build(Expression expression, string expressionText)
    {
        var members = new Stack<string>();
        Expression? current = expression;

        while (current is not null)
        {
            switch (current)
            {
                case UnaryExpression { NodeType: ExpressionType.Convert or ExpressionType.ConvertChecked } unaryExpression:
                    current = unaryExpression.Operand;
                    break;
                case MemberExpression memberExpression:
                    members.Push(ToQueryName(memberExpression.Member.Name));
                    current = memberExpression.Expression;
                    break;
                case ParameterExpression:
                    current = null;
                    break;
                default:
                    throw new NotSupportedException($"The expression '{expressionText}' is not supported. Use only direct property access.");
            }
        }

        if (members.Count == 0)
        {
            throw new NotSupportedException($"The expression '{expressionText}' does not produce a valid property path.");
        }

        return string.Join('/', members);
    }

    internal static bool IsModelProperty(Expression expression)
    {
        Expression? current = expression;

        while (current is not null)
        {
            switch (current)
            {
                case UnaryExpression { NodeType: ExpressionType.Convert or ExpressionType.ConvertChecked } unaryExpression:
                    current = unaryExpression.Operand;
                    break;
                case MemberExpression memberExpression:
                    current = memberExpression.Expression;
                    break;
                case ParameterExpression:
                    return true;
                default:
                    return false;
            }
        }

        return false;
    }

    private static string ToQueryName(string propertyName)
        => NamingStrategy.GetPropertyName(propertyName, hasSpecifiedName: false);
}
