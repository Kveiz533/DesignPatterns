using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public sealed class LocalFileSystem : IFileSystem
{
    public Stream OpenFile(string path)
    {
        return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    }

    public IEnumerable<IFileSystemComponent> GetChildren(string path)
    {
        foreach (string directory in Directory.EnumerateDirectories(path))
        {
            yield return new DirectoryComponent(directory, CombinePath(path, directory));
        }

        foreach (string file in Directory.EnumerateFiles(path))
        {
            yield return new FileComponent(GetFileName(file));
        }
    }

    public void TreeGoTo(string path, Session session)
    {
        session.ChangePath(path);
    }

    public void FileShow(string path, IFormatter formatter)
    {
        using Stream stream = OpenFile(path);
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

    public IDirectoryComponent? GetLinker(string path)
    {
        string directoryName = GetFileName(path);
        return new DirectoryComponent(directoryName, path);
    }
}