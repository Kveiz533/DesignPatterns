using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;

public abstract record GetChildrenResult
{
    private GetChildrenResult() { }

    public sealed record Success(IEnumerable<IFileSystemComponent> Components) : GetChildrenResult;

    public sealed record Failure(string Message) : GetChildrenResult;
}