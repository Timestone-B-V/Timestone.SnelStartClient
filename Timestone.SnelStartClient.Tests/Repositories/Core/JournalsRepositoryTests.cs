using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class JournalsRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenCalled_ForwardsGetRequestToJournalsEndpoint()
    {
        var expectedJournals = new List<JournalModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedJournals);
        IJournalsRepository repository = new JournalsRepository(requestExecutor);

        var result = await repository.ListAsync();

        Assert.Equal(expectedJournals, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "dagboeken");
    }
}
