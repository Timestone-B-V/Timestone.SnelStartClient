using Timestone.SnelStartClient.Models.Core;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Core;

public sealed class AuthorizationRepositoryTests
{
    [Fact]
    public async Task HasUserAccessToAdministrationAsync_WhenUserIdentifierIsProvided_ForwardsGetRequestWithAuthorizationQuery()
    {
        var userIdentifier = Guid.NewGuid();
        var expectedResult = new AuthorizationResultModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedResult);
        IAuthorizationRepository repository = new AuthorizationRepository(requestExecutor);

        var result = await repository.HasUserAccessToAdministrationAsync(userIdentifier);

        Assert.Same(expectedResult, result);
        Assert.IsType<AuthorizationQueryOptions>(requestExecutor.LastQuery);
        Assert.Equal(userIdentifier, ((AuthorizationQueryOptions)requestExecutor.LastQuery!).UserIdentifier);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "authorization/HasUserAccessToAdministration", query: requestExecutor.LastQuery);
    }
}
