using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;

public sealed class FileDeleteCommandBuilder : ISourcePathBuilder
{
    private string? _path;

    public BuildingResult Build()
    {
        return _path is null
            ? new BuildingResult.Failure("Path cannot be null.")
            : new BuildingResult.Success(new FileDeleteCommand(_path));
    }

    public SetArgumentResult SetSourcePath(string sourcePath)
    {
        if (_path is not null)
        {
            return new SetArgumentResult.Failure("Path is already set.");
        }

        _path = sourcePath;
        return new SetArgumentResult.Success(this);
    }
}