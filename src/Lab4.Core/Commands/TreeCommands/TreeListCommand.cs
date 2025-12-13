using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

public sealed class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public CommandResult Execute(Session session)
    {
        if (!session.IsConnected)
        {
            return new CommandResult.Failure("Not connected.");
        }

        var visitor = new ConsoleFileSystemVisitor(
            _depth,
            session.PrintingEntities,
            session.FileSystem);

        string directoryName = session.FileSystem.GetFileName(session.CurrentPath);

        var startDirectory = new DirectoryComponent(directoryName, session.CurrentPath);
        visitor.Visit(startDirectory);

        session.FileSystem.Write(visitor.Value);
        return new CommandResult.Success();
    }
}