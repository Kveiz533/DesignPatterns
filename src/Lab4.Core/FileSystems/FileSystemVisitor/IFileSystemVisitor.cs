using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

public interface IFileSystemVisitor
{
    void Visit(FileComponent file);

    void Visit(DirectoryComponent directory);
}