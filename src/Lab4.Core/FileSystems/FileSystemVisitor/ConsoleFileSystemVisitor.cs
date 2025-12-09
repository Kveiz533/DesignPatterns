using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

public class ConsoleFileSystemVisitor : IFileSystemVisitor
{
    private readonly int _maxDepth;
    private readonly IFileSystem _fileSystem;
    private readonly string _directorySymbol;
    private readonly string _fileSymbol;
    private readonly char _indentSymbol;
    private readonly StringBuilder _builder = new();
    private int _padding;
    private int _currentDepth;

    public string Value => _builder.ToString();

    public ConsoleFileSystemVisitor(
        int depth,
        string directorySymbol,
        string fileSymbol,
        char indentSymbol,
        IFileSystem fileSystem)
    {
        _maxDepth = depth;
        _directorySymbol = directorySymbol;
        _fileSymbol = fileSymbol;
        _indentSymbol = indentSymbol;
        _fileSystem = fileSystem;
    }

    public void Visit(FileComponent file)
    {
        _builder.Append(_indentSymbol, _padding);
        _builder.AppendLine($"{_fileSymbol} {file.Name}");
    }

    public void Visit(DirectoryComponent directory)
    {
        _builder.Append(_indentSymbol, _padding);
        _builder.AppendLine($"{_directorySymbol} {directory.Name}");

        if (_currentDepth >= _maxDepth)
        {
            return;
        }

        GetChildrenResult result = _fileSystem.GetChildren(directory.Path);

        if (result is GetChildrenResult.Success success)
        {
            _padding++;
            _currentDepth++;

            foreach (IFileSystemComponent child in success.Components)
            {
                child.Accept(this);
            }

            _currentDepth--;
            _padding--;
        }
    }
}