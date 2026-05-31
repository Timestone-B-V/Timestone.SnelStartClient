using System.Globalization;
using System.Linq.Expressions;

namespace Timestone.SnelStartClient.Queries;

internal static class ODataFilterExpressionBuilder
{
    internal static string Build<TModel>(Expression<Func<TModel, bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return Visit(predicate.Body);
    }

    private static string Visit(Expression expression) => expression switch
    {
        BinaryExpression binaryExpression => VisitBinary(binaryExpression),
        UnaryExpression { NodeType: ExpressionType.Not } unaryExpression => VisitNot(unaryExpression.Operand),
        UnaryExpression { NodeType: ExpressionType.Convert or ExpressionType.ConvertChecked } unaryExpression => Visit(unaryExpression.Operand),
        MemberExpression memberExpression when IsBooleanProperty(memberExpression) && ODataPropertyPathBuilder.IsModelProperty(memberExpression)
            => $"{ODataPropertyPathBuilder.Build(memberExpression)} eq true",
        MethodCallExpression methodCallExpression => VisitMethodCall(methodCallExpression),
        ConstantExpression constantExpression when constantExpression.Type == typeof(bool)
            => FormatLiteral(constantExpression.Value),
        _ => throw new NotSupportedException($"The expression '{expression}' is not supported for $filter.")
    };

    private static string VisitBinary(BinaryExpression expression)
    {
        if (expression.NodeType is ExpressionType.AndAlso or ExpressionType.OrElse)
        {
            var logicalOperator = expression.NodeType == ExpressionType.AndAlso ? "and" : "or";
            return $"({Visit(expression.Left)} {logicalOperator} {Visit(expression.Right)})";
        }

        var leftModelPropertyType = GetModelPropertyType(expression.Left);
        var rightModelPropertyType = GetModelPropertyType(expression.Right);

        var left = VisitOperand(expression.Left, rightModelPropertyType);
        var right = VisitOperand(expression.Right, leftModelPropertyType);
        var operatorText = expression.NodeType switch
        {
            ExpressionType.Equal => "eq",
            ExpressionType.NotEqual => "ne",
            ExpressionType.GreaterThan => "gt",
            ExpressionType.GreaterThanOrEqual => "ge",
            ExpressionType.LessThan => "lt",
            ExpressionType.LessThanOrEqual => "le",
            _ => throw new NotSupportedException($"Operator '{expression.NodeType}' is not supported for $filter.")
        };

        return $"{left} {operatorText} {right}";
    }

    private static string VisitNot(Expression operand)
    {
        if (operand is UnaryExpression { NodeType: ExpressionType.Convert or ExpressionType.ConvertChecked } unaryExpression)
        {
            operand = unaryExpression.Operand;
        }

        if (operand is MemberExpression memberExpression && IsBooleanProperty(memberExpression) && ODataPropertyPathBuilder.IsModelProperty(memberExpression))
        {
            return $"{ODataPropertyPathBuilder.Build(memberExpression)} eq false";
        }

        return $"not ({Visit(operand)})";
    }

    private static string VisitMethodCall(MethodCallExpression expression)
    {
        if (expression.Method.DeclaringType != typeof(string))
        {
            throw new NotSupportedException($"The method '{expression.Method.Name}' is not supported for $filter.");
        }

        var target = VisitOperand(expression.Object ?? throw new NotSupportedException($"The method '{expression.Method.Name}' is not supported for $filter."));
        var argument = VisitOperand(expression.Arguments.Single());

        return expression.Method.Name switch
        {
            nameof(string.Contains) => $"contains({target},{argument})",
            nameof(string.StartsWith) => $"startswith({target},{argument})",
            nameof(string.EndsWith) => $"endswith({target},{argument})",
            _ => throw new NotSupportedException($"The method '{expression.Method.Name}' is not supported for $filter.")
        };
    }

    private static string VisitOperand(Expression expression, Type? preferredLiteralType = null)
    {
        var originalType = Nullable.GetUnderlyingType(expression.Type) ?? expression.Type;

        if (expression is UnaryExpression { NodeType: ExpressionType.Convert or ExpressionType.ConvertChecked } unaryExpression)
        {
            expression = unaryExpression.Operand;
        }

        if (expression is MemberExpression memberExpression && ODataPropertyPathBuilder.IsModelProperty(memberExpression))
        {
            return ODataPropertyPathBuilder.Build(memberExpression);
        }

        var value = Evaluate(expression);
        var expressionType = Nullable.GetUnderlyingType(expression.Type) ?? expression.Type;
        var preferredType = Nullable.GetUnderlyingType(preferredLiteralType ?? originalType) ?? (preferredLiteralType ?? originalType);
        var targetType = preferredType.IsEnum ? preferredType : expressionType;

        if (value is not null && targetType.IsEnum && value.GetType() != targetType)
        {
            value = Enum.ToObject(targetType, value);
        }

        return FormatLiteral(value);
    }

    private static object? Evaluate(Expression expression)
        => Expression.Lambda(expression).Compile().DynamicInvoke();

    private static bool IsBooleanProperty(MemberExpression expression)
    {
        var type = Nullable.GetUnderlyingType(expression.Type) ?? expression.Type;
        return type == typeof(bool);
    }

    private static Type? GetModelPropertyType(Expression expression)
    {
        if (expression is UnaryExpression { NodeType: ExpressionType.Convert or ExpressionType.ConvertChecked } unaryExpression)
        {
            expression = unaryExpression.Operand;
        }

        return expression is MemberExpression memberExpression && ODataPropertyPathBuilder.IsModelProperty(memberExpression)
            ? Nullable.GetUnderlyingType(memberExpression.Type) ?? memberExpression.Type
            : null;
    }

    private static string FormatLiteral(object? value) => value switch
    {
        null => "null",
        string text => $"'{text.Replace("'", "''", StringComparison.Ordinal)}'",
        bool boolean => boolean ? "true" : "false",
        Guid guid => guid.ToString(),
        DateTimeOffset dateTimeOffset => dateTimeOffset.ToString("O", CultureInfo.InvariantCulture),
        DateTime dateTime => dateTime.ToString("O", CultureInfo.InvariantCulture),
        Enum enumeration => $"'{enumeration}'",
        IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture) ?? string.Empty,
        _ => value.ToString() ?? string.Empty
    };
}
