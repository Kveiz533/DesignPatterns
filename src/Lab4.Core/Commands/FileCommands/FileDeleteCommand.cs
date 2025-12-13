using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public sealed class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public CommandResult Execute(Session session)
    {
        if (!session.IsConnected)
        {
            return new CommandResult.Failure("Not connected.");
        }

        ResolveResult resolvedAbsPath = session.FileSystem.ResolvePath(session.RootPath, session.CurrentPath, _path);
        string absPath;

        if (resolvedAbsPath is ResolveResult.Success success)
        {
            absPath = success.Path;
        }
        else
        {
            return new CommandResult.Failure("Path cannot be resolved.");
        }

        if (!session.FileSystem.FileExists(absPath))
        {
            return new CommandResult.Failure("Path does not exist.");
        }

        session.FileSystem.FileDelete(absPath);
        return new CommandResult.Success();
    }
}