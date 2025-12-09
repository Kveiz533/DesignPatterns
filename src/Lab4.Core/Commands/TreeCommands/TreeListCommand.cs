using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

public sealed class TreeListCommand : ICommand
{
    private readonly int _depth;
    private readonly string _directorySymbol;
    private readonly string _fileSymbol;
    private readonly char _indentSymbol;

    public TreeListCommand(int depth, string directorySymbol, string fileSymbol, char indentSymbol)
    {
        _depth = depth;
        _directorySymbol = directorySymbol;
        _fileSymbol = fileSymbol;
        _indentSymbol = indentSymbol;
    }

    public CommandResult Execute(ISession session)
    {
        if (!session.IsConnected)
        {
            return new CommandResult.Failure("Not connected");
        }

        var visitor = new ConsoleFileSystemVisitor(
            _depth,
            _directorySymbol,
            _fileSymbol,
            _indentSymbol,
            session.FileSystem);

        string directoryName = session.FileSystem.GetFileName(session.CurrentPath);

        var startDirectory = new DirectoryComponent(directoryName, session.CurrentPath);
        visitor.Visit(startDirectory);

        Console.WriteLine(visitor.Value);

        return new CommandResult.Success();
    }
}