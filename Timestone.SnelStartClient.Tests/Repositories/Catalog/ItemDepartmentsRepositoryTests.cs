using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Tests.Repositories;

namespace Timestone.SnelStartClient.Tests.Repositories.Catalog;

public sealed class ItemDepartmentsRepositoryTests
{
    [Fact]
    public async Task ListAsync_WhenCalled_ForwardsGetRequestToItemDepartmentsEndpoint()
    {
        var expectedDepartments = new List<ItemDepartmentModel> { new() };
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDepartments);
        IItemDepartmentsRepository repository = new ItemDepartmentsRepository(requestExecutor);

        var result = await repository.ListAsync();

        Assert.Equal(expectedDepartments, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, "artikelomzetgroepen");
    }

    [Fact]
    public async Task GetAsync_WhenIdentifierIsProvided_ForwardsGetRequestToItemDepartmentEndpoint()
    {
        var departmentId = Guid.NewGuid();
        var expectedDepartment = new ItemDepartmentModel();
        var requestExecutor = RepositoryTestHelper.CreateExecutor(expectedDepartment);
        IItemDepartmentsRepository repository = new ItemDepartmentsRepository(requestExecutor);

        var result = await repository.GetAsync(departmentId);

        Assert.Same(expectedDepartment, result);
        RepositoryTestHelper.AssertRequest(requestExecutor, HttpMethod.Get, $"artikelomzetgroepen/{departmentId}");
    }
}
