using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;

public sealed class FileCopyCommandBuilder : ISourcePathBuilder, IDestinationPathBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public BuildingResult Build()
    {
        return _sourcePath is null || _destinationPath is null
            ? new BuildingResult.Failure("SourcePath or DestinationPath cannot be null.")
            : new BuildingResult.Success(new FileCopyCommand(_sourcePath, _destinationPath));
    }

    public SetArgumentResult SetSourcePath(string sourcePath)
    {
        if (_sourcePath is not null)
        {
            return new SetArgumentResult.Failure("SourcePath is already set.");
        }

        _sourcePath = sourcePath;
        return new SetArgumentResult.Success(this);
    }

    public SetArgumentResult SetDestinationPath(string destinationPath)
    {
        if (_destinationPath is not null)
        {
            return new SetArgumentResult.Failure("DestinationPath is already set.");
        }

        _destinationPath = destinationPath;
        return new SetArgumentResult.Success(this);
    }
}