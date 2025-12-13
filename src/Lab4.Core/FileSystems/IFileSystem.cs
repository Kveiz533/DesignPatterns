using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    OpenStreamResult OpenFile(string path);

    IEnumerable<IFileSystemComponent> GetChildren(string path);

    void Write(string value);

    void TreeGoTo(string path, Session session);

    void FileShow(Stream stream, IFormatter formatter);

    void FileMove(string sourcePath, string destinationPath);

    void FileCopy(string sourcePath, string destinationPath);

    void FileDelete(string path);

    void FileRename(string sourcePath, string destinationPath);

    bool FileExists(string path);

    bool DirectoryExists(string path);

    string CombinePath(string path1, string path2);

    ResolveResult ResolvePath(string rootPath, string currentPath, string path);

    string GetFileName(string path);
}