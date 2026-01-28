using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

public sealed class TreeListCommand : ICommand
{
    private readonly int _depth;
    private readonly PrintingEntities _printingEntities;
    private readonly TextWriter _textWriter;

    public TreeListCommand(int depth, PrintingEntities printingEntities, TextWriter textWriter)
    {
        _depth = depth;
        _printingEntities = printingEntities;
        _textWriter = textWriter;
    }

    public CommandResult Execute(Session session)
    {
        if (!session.IsConnected)
        {
            return new CommandResult.Failure("Not connected.");
        }

        if (!session.FileSystem.DirectoryExists(session.CurrentPath))
        {
            return new CommandResult.Failure("Directory does not exist.");
        }

        var visitor = new ConsoleFileSystemVisitor(
            _depth,
            _printingEntities,
            session.FileSystem);

        IDirectoryComponent? startDirectory = session.FileSystem.GetLinker(session.CurrentPath);

        if (startDirectory is null)
        {
            return new CommandResult.Failure("Directory does not exist.");
        }

        visitor.Visit(startDirectory);
        _textWriter.WriteLine(visitor.Value);

        return new CommandResult.Success();
    }
}