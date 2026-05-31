namespace Timestone.SnelStartClient.Tests.Queries.TestModels;

internal sealed class FilterTestModel
{
    internal bool IsActive { get; init; }

    internal string Name { get; init; } = string.Empty;

    internal decimal Amount { get; init; }

    internal DateTime DueDate { get; init; }

    internal NestedFilterReferenceModel Nested { get; init; } = new();

    internal FilterStatus Status { get; init; }

    internal DateTimeOffset CreatedOn { get; init; }
}
