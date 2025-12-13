using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public sealed class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
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

        if (!session.FileSystem.FileExists(sourceAbsPath))
        {
            return new CommandResult.Failure($"Cannot rename file {sourceAbsPath}.");
        }

        string? directory = Path.GetDirectoryName(sourceAbsPath);

        if (directory is null)
        {
            return new CommandResult.Failure("Cannot rename root directory or invalid path.");
        }

        string destinationAbsPath = session.FileSystem.CombinePath(directory, _name);

        if (session.FileSystem.FileExists(destinationAbsPath))
        {
            return new CommandResult.Failure($"File with name '{_name}' already exists in this directory.");
        }

        session.FileSystem.FileRename(sourceAbsPath, destinationAbsPath);
        return new CommandResult.Success();
    }
}