using Timestone.SnelStartClient.Tests.TestDoubles;

namespace Timestone.SnelStartClient.Tests.Repositories;

internal static class RepositoryTestHelper
{
    internal static RecordingRequestExecutor CreateExecutor(object? result)
        => new()
        {
            SendAsyncResultFactory = (_, _, _, _, _) => Task.FromResult(result)
        };

    internal static void AssertRequest(RecordingRequestExecutor requestExecutor, HttpMethod method, string path, object? body = null, object? query = null)
    {
        Assert.Equal(method, requestExecutor.LastMethod);
        Assert.Equal(path, requestExecutor.LastPath);

        if (body is null)
        {
            Assert.Null(requestExecutor.LastBody);
        }
        else
        {
            Assert.Same(body, requestExecutor.LastBody);
        }

        if (query is null)
        {
            Assert.Null(requestExecutor.LastQuery);
        }
        else
        {
            Assert.Same(query, requestExecutor.LastQuery);
        }
    }
}
