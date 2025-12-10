using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public sealed class FileCopyCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResult Execute(ISession session)
    {
        if (!session.IsConnected)
        {
            return new CommandResult.Failure("Not connected.");
        }

        ResolveResult resolveAbsSourcePath = session.FileSystem.ResolvePath(session.RootPath, session.CurrentPath, _sourcePath);
        ResolveResult resolvedAbsDestinationPath = session.FileSystem.ResolvePath(session.RootPath, session.CurrentPath, _destinationPath);
        string absSourcePath;
        string absDestinationPath;

        if (resolveAbsSourcePath is ResolveResult.Success success1)
        {
            absSourcePath = success1.Path;
        }
        else
        {
            return new CommandResult.Failure("SourcePath cannot be resolved.");
        }

        if (resolvedAbsDestinationPath is ResolveResult.Success success2)
        {
            absDestinationPath = success2.Path;
        }
        else
        {
            return new CommandResult.Failure("DestinationPath cannot be resolved.");
        }

        if (!session.FileSystem.FileExists(absSourcePath))
        {
            return new CommandResult.Failure("SourcePath does not exist.");
        }

        if (!session.FileSystem.DirectoryExists(absDestinationPath))
        {
            return new CommandResult.Failure("DestinationPath does not exist.");
        }

        string fileName = session.FileSystem.GetFileName(absSourcePath);
        string absDestinationFile = session.FileSystem.CombinePath(absDestinationPath, fileName);

        if (absDestinationFile == absSourcePath)
        {
            return new CommandResult.Failure("Cannot copy file into itself.");
        }

        if (session.FileSystem.FileExists(absDestinationFile))
        {
            return new CommandResult.Failure($"File '{fileName}' already exists in destination directory.");
        }

        session.FileSystem.FileCopy(absSourcePath, absDestinationFile);
        return new CommandResult.Success();
    }
}