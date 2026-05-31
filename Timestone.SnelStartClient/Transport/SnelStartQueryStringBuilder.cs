using System.Globalization;
using System.Reflection;

namespace Timestone.SnelStartClient.Transport;

internal static class SnelStartQueryStringBuilder
{
    internal static string AppendQueryString(string path, object? query)
    {
        if (query is null)
        {
            return path;
        }

        var pairs = new List<string>();

        foreach (var property in query.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            if (!property.CanRead)
            {
                continue;
            }

            var value = property.GetValue(query);
            if (value is null)
            {
                continue;
            }

            var attribute = property.GetCustomAttribute<QueryNameAttribute>();
            var name = attribute?.Name ?? property.Name;
            var formattedValue = FormatValue(value);

            if (formattedValue is null)
            {
                continue;
            }

            pairs.Add($"{Uri.EscapeDataString(name)}={Uri.EscapeDataString(formattedValue)}");
        }

        if (pairs.Count == 0)
        {
            return path;
        }

        var separator = path.Contains('?', StringComparison.Ordinal) ? "&" : "?";
        return string.Concat(path, separator, string.Join("&", pairs));
    }

    private static string? FormatValue(object value) => value switch
    {
        string text when string.IsNullOrWhiteSpace(text) => null,
        string text => text,
        DateTimeOffset dateTimeOffset => dateTimeOffset.ToString("O", CultureInfo.InvariantCulture),
        DateTime dateTime => dateTime.ToString("O", CultureInfo.InvariantCulture),
        DateOnly dateOnly => dateOnly.ToString("O", CultureInfo.InvariantCulture),
        bool boolean => boolean ? "true" : "false",
        Enum enumeration => enumeration.ToString(),
        IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
        _ => value.ToString()
    };
}
