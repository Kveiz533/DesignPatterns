using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public sealed class FileShowCommand : ICommand
{
    private readonly string _path;
    private readonly IFormatter _formatter;

    public FileShowCommand(string path, IFormatter formatter)
    {
        _path = path;
        _formatter = formatter;
    }

    public CommandResult Execute(Session session)
    {
        if (!session.IsConnected)
        {
            return new CommandResult.Failure("Not connected.");
        }

        ResolveResult resolveAbsPath = session.FileSystem.ResolvePath(session.RootPath, session.CurrentPath, _path);

        if (resolveAbsPath is not ResolveResult.Success { Path: var sourceAbsPath })
        {
            return new CommandResult.Failure("SourcePath cannot be resolved.");
        }

        Stream openStream = session.FileSystem.OpenFile(sourceAbsPath);
        _formatter.Format(openStream);
        return new CommandResult.Success();
    }
}