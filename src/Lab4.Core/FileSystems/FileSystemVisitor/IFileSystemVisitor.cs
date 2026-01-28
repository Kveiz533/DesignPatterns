using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

public interface IFileSystemVisitor
{
    void Visit(IFileComponent file);

    void Visit(IDirectoryComponent directory);
}