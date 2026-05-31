using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Tests.Transport;

public sealed class SnelStartQueryStringBuilderTests
{
    [Fact]
    public void AppendQueryString_WhenQueryIsNull_ReturnsOriginalPath()
    {
        var result = SnelStartQueryStringBuilder.AppendQueryString("artikelen", query: null);

        Assert.Equal("artikelen", result);
    }

    [Fact]
    public void AppendQueryString_WhenQueryHasValues_UsesQueryNamesAndInvariantFormatting()
    {
        var relationId = Guid.NewGuid();
        var query = new ArticleQueryOptions
        {
            RelationId = relationId,
            Amount = 2,
            Skip = 5,
            Top = 10,
            Filter = "omschrijving eq 'abc'"
        };

        var result = SnelStartQueryStringBuilder.AppendQueryString("artikelen", query);
        var parameters = ParseQuery(result);

        Assert.Equal(relationId.ToString(), parameters["relatieId"]);
        Assert.Equal("2", parameters["aantal"]);
        Assert.Equal("5", parameters["$skip"]);
        Assert.Equal("10", parameters["$top"]);
        Assert.Equal("omschrijving eq 'abc'", parameters["$filter"]);
    }

    [Fact]
    public void AppendQueryString_WhenPathAlreadyContainsQuery_UsesAmpersandSeparator()
    {
        var result = SnelStartQueryStringBuilder.AppendQueryString("artikelen?existing=true", new { page = 2 });

        Assert.Equal("artikelen?existing=true&page=2", result);
    }

    [Fact]
    public void AppendQueryString_WhenStringValueIsWhitespace_OmitsParameter()
    {
        var result = SnelStartQueryStringBuilder.AppendQueryString("artikelen", new { search = "   ", page = 1 });
        var parameters = ParseQuery(result);

        Assert.DoesNotContain("search", parameters.Keys);
        Assert.Equal("1", parameters["page"]);
    }

    private static IReadOnlyDictionary<string, string> ParseQuery(string pathAndQuery)
    {
        var queryString = pathAndQuery.Split('?', 2)[1];

        return queryString
            .Split('&', StringSplitOptions.RemoveEmptyEntries)
            .Select(part => part.Split('=', 2))
            .ToDictionary(
                part => Uri.UnescapeDataString(part[0]),
                part => Uri.UnescapeDataString(part[1]),
                StringComparer.Ordinal);
    }
}
