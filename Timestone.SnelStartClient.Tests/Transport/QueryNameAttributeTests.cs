using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Tests.Transport;

public sealed class QueryNameAttributeTests
{
    [Fact]
    public void Constructor_WhenNameIsProvided_SetsNameProperty()
    {
        var attribute = new QueryNameAttribute("$filter");

        Assert.Equal("$filter", attribute.Name);
    }
}
