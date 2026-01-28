namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;

public interface IDirectoryComponent : IFileSystemComponent
{
    string Name { get; }

    string Path { get; }
}