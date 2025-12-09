using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemVisitor visitor);
}