using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

public class ConsoleFileSystemVisitor : IFileSystemVisitor
{
    private readonly int _maxDepth;
    private readonly IFileSystem _fileSystem;
    private readonly PrintingEntities _printingEntities;
    private readonly StringBuilder _builder = new();
    private int _padding;
    private int _currentDepth;

    public string Value => _builder.ToString();

    public ConsoleFileSystemVisitor(
        int depth,
        PrintingEntities printingEntities,
        IFileSystem fileSystem)
    {
        _maxDepth = depth;
        _printingEntities = printingEntities;
        _fileSystem = fileSystem;
    }

    public void Visit(FileComponent file)
    {
        _builder.Append(_printingEntities.IndentSymbol, _padding);
        _builder.AppendLine($"{_printingEntities.FileSymbol} {file.Name}");
    }

    public void Visit(DirectoryComponent directory)
    {
        _builder.Append(_printingEntities.IndentSymbol, _padding);
        _builder.AppendLine($"{_printingEntities.DirectorySymbol} {directory.Name}");

        if (_currentDepth >= _maxDepth)
        {
            return;
        }

        _padding++;
        _currentDepth++;

        foreach (IFileSystemComponent child in _fileSystem.GetChildren(directory.Path))
        {
            child.Accept(this);
        }

        _currentDepth--;
        _padding--;
    }
}