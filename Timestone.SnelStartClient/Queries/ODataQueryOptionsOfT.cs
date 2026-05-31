using System.Linq.Expressions;

namespace Timestone.SnelStartClient.Queries;

/// <summary>
/// General OData query options with typed support for <c>$select</c>.
/// </summary>
/// <typeparam name="TModel">The model type of the endpoint.</typeparam>
public class ODataQueryOptions<TModel> : ODataQueryOptions
{
    private readonly List<(LambdaExpression Expression, bool Descending)> _orderings = [];

    /// <summary>
    /// Builds a typed <c>$select</c> query for the specified model type.
    /// </summary>
    /// <param name="properties">The properties to select.</param>
    /// <returns>The current query options.</returns>
    public ODataQueryOptions<TModel> SelectProperties(params Expression<Func<TModel, object?>>[] properties)
    {
        Select = ODataSelectExpressionBuilder.Build(properties);
        return this;
    }

    /// <summary>
    /// Sets the typed OData filter.
    /// </summary>
    public ODataQueryOptions<TModel> Where(Expression<Func<TModel, bool>> predicate)
    {
        Filter = ODataFilterExpressionBuilder.Build(predicate);
        return this;
    }

    /// <summary>
    /// Adds a typed additional OData filter with <c>and</c>.
    /// </summary>
    public ODataQueryOptions<TModel> AndWhere(Expression<Func<TModel, bool>> predicate)
    {
        var filter = ODataFilterExpressionBuilder.Build(predicate);
        Filter = string.IsNullOrWhiteSpace(Filter) ? filter : $"({Filter}) and ({filter})";
        return this;
    }

    /// <summary>
    /// Adds a typed additional OData filter with <c>or</c>.
    /// </summary>
    public ODataQueryOptions<TModel> OrWhere(Expression<Func<TModel, bool>> predicate)
    {
        var filter = ODataFilterExpressionBuilder.Build(predicate);
        Filter = string.IsNullOrWhiteSpace(Filter) ? filter : $"({Filter}) or ({filter})";
        return this;
    }

    /// <summary>
    /// Sets the typed OData sorting in ascending order.
    /// </summary>
    public ODataQueryOptions<TModel> OrderBy<TProperty>(Expression<Func<TModel, TProperty>> property)
    {
        _orderings.Clear();
        _orderings.Add((property, Descending: false));
        OrderByExpression = ODataOrderByExpressionBuilder.Build(_orderings);
        return this;
    }

    /// <summary>
    /// Sets the typed OData sorting in descending order.
    /// </summary>
    public ODataQueryOptions<TModel> OrderByDescending<TProperty>(Expression<Func<TModel, TProperty>> property)
    {
        _orderings.Clear();
        _orderings.Add((property, Descending: true));
        OrderByExpression = ODataOrderByExpressionBuilder.Build(_orderings);
        return this;
    }

    /// <summary>
    /// Adds the next typed ascending OData sorting.
    /// </summary>
    public ODataQueryOptions<TModel> ThenBy<TProperty>(Expression<Func<TModel, TProperty>> property)
    {
        _orderings.Add((property, Descending: false));
        OrderByExpression = ODataOrderByExpressionBuilder.Build(_orderings);
        return this;
    }

    /// <summary>
    /// Adds the next typed descending OData sorting.
    /// </summary>
    public ODataQueryOptions<TModel> ThenByDescending<TProperty>(Expression<Func<TModel, TProperty>> property)
    {
        _orderings.Add((property, Descending: true));
        OrderByExpression = ODataOrderByExpressionBuilder.Build(_orderings);
        return this;
    }
}
