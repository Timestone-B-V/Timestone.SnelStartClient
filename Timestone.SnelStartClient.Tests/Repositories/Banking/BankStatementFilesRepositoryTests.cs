using Timestone.SnelStartClient.Models.Banking;
using Timestone.SnelStartClient.Repositories.Banking;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Banking;

public sealed class BankStatementFilesRepositoryTests
{
    [Fact]
    public async Task CreateAsync_WhenFilesAreProvided_ForwardsPostRequestToBankStatementFilesEndpoint()
    {
        IReadOnlyList<BankStatementFileModel> files = [new BankStatementFileModel()];
        var expectedResponse = new List<BankStatementFileResponseModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedResponse);
        IBankStatementFilesRepository repository = new BankStatementFilesRepository(requestExecutor);

        var result = await repository.CreateAsync(files);

        Assert.Equal(expectedResponse, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "bankafschriftbestanden", files);
    }

    [Fact]
    public async Task CreateAsync_WhenExecutorReturnsNull_ReturnsEmptyList()
    {
        IReadOnlyList<BankStatementFileModel> files = [new BankStatementFileModel()];
        var requestExecutor = RepositoryTestHelper.CreateExecutor(null);
        IBankStatementFilesRepository repository = new BankStatementFilesRepository(requestExecutor);

        var result = await repository.CreateAsync(files);

        Assert.Empty(result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Post, "bankafschriftbestanden", files);
    }
}
