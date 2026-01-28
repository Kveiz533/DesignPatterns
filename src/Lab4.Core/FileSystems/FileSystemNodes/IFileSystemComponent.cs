using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

public interface IFileSystemComponent
{
    void Accept(IFileSystemVisitor visitor);
}