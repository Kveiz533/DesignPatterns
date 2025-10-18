namespace Itmo.ObjectOrientedProgramming.Lab2.UserEntities;

public abstract record MarkResult
{
    private MarkResult() { }

    public sealed record Marked : MarkResult;

    public sealed record NotFound : MarkResult;

    public sealed record AlreadyMarked : MarkResult;
}