namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;

public abstract record ResolveResult
{
    private ResolveResult() { }

    public sealed record Success(string Path) : ResolveResult;

    public sealed record Failure(string Message) : ResolveResult;
}