using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public sealed class LocalFileSystem : IFileSystem
{
    public OpenStreamResult OpenFile(string path)
    {
        return new OpenStreamResult.Success(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
    }

    public GetChildrenResult GetChildren(string path)
    {
        return new GetChildrenResult.Success(new DirectoryInfo(path)
            .EnumerateFileSystemInfos()
            .Select<FileSystemInfo, IFileSystemComponent>(item => item switch
            {
                DirectoryInfo directory => new DirectoryComponent(directory.Name, directory.FullName),
                FileInfo file => new FileComponent(file.Name),
                _ => throw new InvalidOperationException("Unknown file system item."),
            }));
    }

    public void TreeGoTo(string path, ISession session)
    {
        session.ChangePath(path);
    }

    public void FileShow(Stream stream, IFormatter formatter)
    {
        formatter.Format(stream);
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void FileDelete(string path)
    {
        File.Delete(path);
    }

    public void FileRename(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public string CombinePath(string path1, string path2)
    {
        return Path.Combine(path1, path2);
    }

    public ResolveResult ResolvePath(string rootPath, string currentPath, string path)
    {
        string combinedPath;
        bool isAbsolutePath = path.StartsWith(Path.DirectorySeparatorChar) || path.StartsWith(Path.AltDirectorySeparatorChar);

        if (isAbsolutePath)
        {
            string relativeToRoot = path.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            combinedPath = Path.Combine(rootPath, relativeToRoot);
        }
        else
        {
            combinedPath = Path.Combine(currentPath, path);
        }

        string fullPath = Path.GetFullPath(combinedPath);

        return fullPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase)
            ? new ResolveResult.Success(fullPath)
            : new ResolveResult.Failure("Path is outside the connected file system.");
    }

    public string GetFileName(string path)
    {
        return Path.GetFileName(path);
    }
}