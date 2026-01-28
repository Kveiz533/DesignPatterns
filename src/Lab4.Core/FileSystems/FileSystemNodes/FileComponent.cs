using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

public class FileComponent : IFileComponent
{
    public string Name { get; }

    public FileComponent(string name)
    {
        Name = name;
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.Visit(this);
    }
}