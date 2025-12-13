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
        string sourceAbsPath;

        if (resolveAbsPath is ResolveResult.Success resolveAbsPathSuccess)
        {
            sourceAbsPath = resolveAbsPathSuccess.Path;
        }
        else
        {
            return new CommandResult.Failure("SourcePath cannot be resolved.");
        }

        OpenStreamResult openStream = session.FileSystem.OpenFile(sourceAbsPath);

        if (openStream is OpenStreamResult.Success openStreamSuccess)
        {
            session.FileSystem.FileShow(openStreamSuccess.Stream, _formatter);
            return new CommandResult.Success();
        }

        return new CommandResult.Failure("Stream cannot be opened.");
    }
}