using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public sealed class DefaultFileSystem : IFileSystem
{
    public Stream OpenFile(string path)
    {
        return new MemoryStream();
    }

    public IEnumerable<IFileSystemComponent> GetChildren(string path)
    {
        yield break;
    }

    public void TreeGoTo(string path, Session session) { }

    public void FileMove(string sourcePath, string destinationPath) { }

    public void FileCopy(string sourcePath, string destinationPath) { }

    public void FileDelete(string path) { }

    public void FileRename(string sourcePath, string destinationPath) { }

    public bool FileExists(string path)
    {
        return false;
    }

    public bool DirectoryExists(string path)
    {
        return false;
    }

    public string CombinePath(string path1, string path2)
    {
        return string.Empty;
    }

    public ResolveResult ResolvePath(string rootPath, string currentPath, string path)
    {
        return new ResolveResult.Failure("System is disconnected.");
    }

    public string GetFileName(string path)
    {
        return string.Empty;
    }

    public IDirectoryComponent? GetLinker(string path)
    {
        return null;
    }
}