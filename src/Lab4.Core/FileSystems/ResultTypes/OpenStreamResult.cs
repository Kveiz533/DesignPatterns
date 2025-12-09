namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;

public abstract record OpenStreamResult
{
    private OpenStreamResult() { }

    public sealed record Success(Stream Stream) : OpenStreamResult;

    public sealed record Failure(string Message) : OpenStreamResult;
}