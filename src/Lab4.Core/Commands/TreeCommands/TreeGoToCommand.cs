using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

public sealed class TreeGoToCommand : ICommand
{
    private readonly string _sourcePath;

    public TreeGoToCommand(string sourcePath)
    {
        _sourcePath = sourcePath;
    }

    public CommandResult Execute(Session session)
    {
        if (!session.IsConnected)
        {
            return new CommandResult.Failure("Not connected.");
        }

        ResolveResult resolveAbsPath = session.FileSystem.ResolvePath(session.RootPath, session.CurrentPath, _sourcePath);

        if (resolveAbsPath is not ResolveResult.Success { Path: var sourceAbsPath })
        {
            return new CommandResult.Failure("SourcePath cannot be resolved.");
        }

        session.FileSystem.TreeGoTo(sourceAbsPath, session);
        return new CommandResult.Success();
    }
}