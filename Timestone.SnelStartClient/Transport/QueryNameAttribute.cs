namespace Timestone.SnelStartClient.Transport;

/// <summary>
/// Specifies the query string name for a property.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class QueryNameAttribute : Attribute
{
    /// <summary>
    /// Initializes a new attribute.
    /// </summary>
    /// <param name="name">The query string name.</param>
    public QueryNameAttribute(string name)
    {
        Name = name;
    }

    /// <summary>
    /// The query string name.
    /// </summary>
    public string Name { get; }
}
