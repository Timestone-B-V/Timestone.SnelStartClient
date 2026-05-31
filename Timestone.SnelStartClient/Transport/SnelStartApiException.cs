using System.Net;
using Newtonsoft.Json.Linq;

namespace Timestone.SnelStartClient.Transport;

/// <summary>
/// Exception thrown when the SnelStart API returns an unsuccessful response.
/// </summary>
public sealed class SnelStartApiException : Exception
{
    /// <summary>
    /// Initializes a new exception for a failed API call.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="requestUri">The request URI.</param>
    /// <param name="responseBody">The response body.</param>
    public SnelStartApiException(HttpStatusCode statusCode, Uri requestUri, string? responseBody)
        : base(BuildMessage(statusCode, requestUri, responseBody))
    {
        StatusCode = statusCode;
        RequestUri = requestUri;
        ResponseBody = responseBody;
        ApiMessage = TryExtractApiMessage(responseBody);
    }

    /// <summary>
    /// The HTTP status code.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// The request URI.
    /// </summary>
    public Uri RequestUri { get; }

    /// <summary>
    /// The response body, when available.
    /// </summary>
    public string? ResponseBody { get; }

    /// <summary>
    /// The parsed API message from the response body, when available.
    /// </summary>
    public string? ApiMessage { get; }

    private static string BuildMessage(HttpStatusCode statusCode, Uri requestUri, string? responseBody)
    {
        var requestPath = string.IsNullOrWhiteSpace(requestUri.AbsolutePath) ? requestUri.ToString() : requestUri.AbsolutePath;
        var message = $"Status code {(int)statusCode} ({statusCode}) in '{requestPath}'.";
        var apiMessage = TryExtractApiMessage(responseBody);

        return string.IsNullOrWhiteSpace(apiMessage)
            ? message
            : $"{message} {apiMessage}";
    }

    private static string? TryExtractApiMessage(string? responseBody)
    {
        if (string.IsNullOrWhiteSpace(responseBody))
        {
            return null;
        }

        var trimmedResponseBody = responseBody.Trim();
        if (!trimmedResponseBody.StartsWith('{') && !trimmedResponseBody.StartsWith('['))
        {
            return trimmedResponseBody;
        }

        try
        {
            var token = JToken.Parse(trimmedResponseBody);
            var messages = ExtractMessages(token)
                .Where(static value => !string.IsNullOrWhiteSpace(value))
                .Distinct(StringComparer.Ordinal)
                .ToArray();

            return messages.Length == 0
                ? trimmedResponseBody
                : string.Join(" | ", messages);
        }
        catch
        {
            return trimmedResponseBody;
        }
    }

    private static IEnumerable<string> ExtractMessages(JToken token)
    {
        if (token is JObject obj)
        {
            var message = GetPropertyValue(obj, "message") ?? GetPropertyValue(obj, "description");
            var errorCode = GetPropertyValue(obj, "errorCode");

            if (!string.IsNullOrWhiteSpace(message))
            {
                yield return string.IsNullOrWhiteSpace(errorCode)
                    ? message
                    : $"{errorCode}: {message}";
            }

            foreach (var detail in ExtractDetails(obj))
            {
                yield return detail;
            }

            foreach (var modelStateMessage in ExtractModelStateMessages(obj))
            {
                yield return modelStateMessage;
            }

            foreach (var property in obj.Properties())
            {
                if (string.Equals(property.Name, "details", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(property.Name, "modelState", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                foreach (var nestedMessage in ExtractMessages(property.Value))
                {
                    yield return nestedMessage;
                }
            }
        }

        if (token is JArray array)
        {
            foreach (var item in array)
            {
                foreach (var nestedMessage in ExtractMessages(item))
                {
                    yield return nestedMessage;
                }
            }
        }
    }

    private static string? GetPropertyValue(JObject obj, string propertyName)
        => obj.Properties()
            .FirstOrDefault(property => string.Equals(property.Name, propertyName, StringComparison.OrdinalIgnoreCase))?
            .Value
            .Value<string>();

    private static IEnumerable<string> ExtractDetails(JObject obj)
    {
        var detailsProperty = obj.Properties()
            .FirstOrDefault(property => string.Equals(property.Name, "details", StringComparison.OrdinalIgnoreCase));

        if (detailsProperty is null)
        {
            yield break;
        }

        foreach (var detail in ExtractPlainTextValues(detailsProperty.Value))
        {
            yield return detail;
        }
    }

    private static IEnumerable<string> ExtractModelStateMessages(JObject obj)
    {
        var modelStateProperty = obj.Properties()
            .FirstOrDefault(property => string.Equals(property.Name, "modelState", StringComparison.OrdinalIgnoreCase));

        if (modelStateProperty?.Value is not JObject modelStateObject)
        {
            yield break;
        }

        foreach (var field in modelStateObject.Properties())
        {
            foreach (var error in ExtractPlainTextValues(field.Value))
            {
                yield return string.IsNullOrWhiteSpace(field.Name)
                    ? error
                    : $"{field.Name}: {error}";
            }
        }
    }

    private static IEnumerable<string> ExtractPlainTextValues(JToken token)
    {
        switch (token)
        {
            case JValue value when value.Type == JTokenType.String:
            {
                var text = value.Value<string>();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    yield return text;
                }

                break;
            }
            case JArray array:
                foreach (var item in array)
                {
                    foreach (var text in ExtractPlainTextValues(item))
                    {
                        yield return text;
                    }
                }

                break;
            case JObject nestedObject:
                foreach (var property in nestedObject.Properties())
                {
                    foreach (var text in ExtractPlainTextValues(property.Value))
                    {
                        yield return text;
                    }
                }

                break;
        }
    }
}
