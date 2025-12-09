using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public sealed class DefaultFileSystem : IFileSystem
{
    public OpenStreamResult OpenFile(string path)
    {
        return new OpenStreamResult.Failure("Can't open file");
    }

    public GetChildrenResult GetChildren(string path)
    {
        return new GetChildrenResult.Failure("Can't get children");
    }

    public void TreeGoTo(string path, ISession session) { }

    public void FileShow(Stream stream, IFormatter formatter) { }

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
        return new ResolveResult.Failure("System is disconnected");
    }

    public string GetFileName(string path)
    {
        return string.Empty;
    }
}