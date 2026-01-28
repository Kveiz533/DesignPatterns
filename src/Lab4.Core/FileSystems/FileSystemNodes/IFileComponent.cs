namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

public interface IFileComponent : IFileSystemComponent
{
    string Name { get; }
}