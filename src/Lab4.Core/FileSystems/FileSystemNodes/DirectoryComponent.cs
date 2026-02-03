using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

public class DirectoryComponent : IDirectoryComponent
{
    public string Path { get; }

    public string Name { get; }

    public DirectoryComponent(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.Visit(this);
    }
}