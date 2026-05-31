using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class EchoRepositoryTests
{
    [Fact]
    public async Task TestAsync_WhenInputContainsReservedCharacters_UsesEscapedInputInPath()
    {
        var expectedResult = new EchoResultModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedResult);
        IEchoRepository repository = new EchoRepository(requestExecutor);

        var result = await repository.TestAsync("hello world/meer");

        Assert.Same(expectedResult, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "echo/hello%20world%2Fmeer");
    }
}
