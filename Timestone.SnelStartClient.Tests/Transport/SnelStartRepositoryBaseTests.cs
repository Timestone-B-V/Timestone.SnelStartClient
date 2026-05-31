using Timestone.SnelStartClient.Tests.TestDoubles;

namespace Timestone.SnelStartClient.Tests.Transport;

public sealed class SnelStartRepositoryBaseTests
{
    [Fact]
    public async Task GetListAsync_WhenExecutorReturnsNull_ReturnsEmptyReadOnlyList()
    {
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(null)
        };
        var repository = new TestRepository(requestExecutor);

        var result = await repository.InvokeGetListAsync<string>("artikelen");

        Assert.Empty(result);
        Assert.Equal(HttpMethod.Get, requestExecutor.LastMethod);
        Assert.Equal("artikelen", requestExecutor.LastPath);
    }

    [Fact]
    public async Task PostAsync_WhenBodyAndQueryAreProvided_ForwardsBothToRequestExecutor()
    {
        var body = new { Omschrijving = "Test" };
        var query = new { includeInactive = true };
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>("created")
        };
        var repository = new TestRepository(requestExecutor);

        var result = await repository.InvokePostAsync<string>("artikelen", body, query);

        Assert.Equal("created", result);
        Assert.Equal(HttpMethod.Post, requestExecutor.LastMethod);
        Assert.Same(body, requestExecutor.LastBody);
        Assert.Same(query, requestExecutor.LastQuery);
    }

    [Fact]
    public async Task GetAsync_WhenQueryAndCancellationTokenAreProvided_ForwardsBothToRequestExecutor()
    {
        var cancellationToken = new CancellationTokenSource().Token;
        var query = new { includeInactive = true };
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, token) => Task.FromResult<object?>(token)
        };
        var repository = new TestRepository(requestExecutor);

        var result = await repository.InvokeGetAsync<CancellationToken>("artikelen/1", query, cancellationToken);

        Assert.Equal(cancellationToken, result);
        Assert.Equal(HttpMethod.Get, requestExecutor.LastMethod);
        Assert.Equal("artikelen/1", requestExecutor.LastPath);
        Assert.Null(requestExecutor.LastBody);
        Assert.Same(query, requestExecutor.LastQuery);
    }

    [Fact]
    public async Task PutAsync_WhenBodyAndQueryAreProvided_ForwardsBothToRequestExecutor()
    {
        var body = new { Omschrijving = "Bijgewerkt" };
        var query = new { includeInactive = true };
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>("updated")
        };
        var repository = new TestRepository(requestExecutor);

        var result = await repository.InvokePutAsync<string>("artikelen/1", body, query);

        Assert.Equal("updated", result);
        Assert.Equal(HttpMethod.Put, requestExecutor.LastMethod);
        Assert.Equal("artikelen/1", requestExecutor.LastPath);
        Assert.Same(body, requestExecutor.LastBody);
        Assert.Same(query, requestExecutor.LastQuery);
    }

    [Fact]
    public async Task GetListAsync_WhenExecutorReturnsItems_ReturnsSameItems()
    {
        var items = new List<string> { "first", "second" };
        var requestExecutor = new RecordingRequestExecutor
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult<object?>(items)
        };
        var repository = new TestRepository(requestExecutor);

        var result = await repository.InvokeGetListAsync<string>("artikelen");

        Assert.Equal(items, result);
    }

    [Fact]
    public async Task DeleteAsync_WhenExecutorCompletes_ReturnsTrue()
    {
        var requestExecutor = new RecordingRequestExecutor();
        var repository = new TestRepository(requestExecutor);

        var deleted = await repository.InvokeDeleteAsync("artikelen/1");

        Assert.True(deleted);
        Assert.Equal(HttpMethod.Delete, requestExecutor.LastMethod);
        Assert.Equal("artikelen/1", requestExecutor.LastPath);
    }
}
