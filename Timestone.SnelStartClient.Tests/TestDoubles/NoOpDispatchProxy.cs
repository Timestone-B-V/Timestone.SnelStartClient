using System.Reflection;

namespace Timestone.SnelStartClient.Tests.TestDoubles;

internal class NoOpDispatchProxy : DispatchProxy
{
    internal static T Create<T>() where T : class
        => Create<T, NoOpDispatchProxy>();

    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        if (targetMethod is null)
        {
            return null;
        }

        if (targetMethod.ReturnType == typeof(void))
        {
            return null;
        }

        if (targetMethod.ReturnType == typeof(Task))
        {
            return Task.CompletedTask;
        }

        if (targetMethod.ReturnType.IsGenericType && targetMethod.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
        {
            var resultType = targetMethod.ReturnType.GetGenericArguments()[0];
            var defaultValue = resultType.IsValueType ? Activator.CreateInstance(resultType) : null;
            return typeof(Task)
                .GetMethod(nameof(Task.FromResult))!
                .MakeGenericMethod(resultType)
                .Invoke(null, [defaultValue]);
        }

        if (targetMethod.ReturnType.IsValueType)
        {
            return Activator.CreateInstance(targetMethod.ReturnType);
        }

        return null;
    }
}
