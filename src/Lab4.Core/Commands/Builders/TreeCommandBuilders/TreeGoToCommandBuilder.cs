using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;

public sealed class TreeGoToCommandBuilder : ISourcePathBuilder
{
    private string? _path;

    public BuildingResult Build()
    {
        return _path is null
            ? new BuildingResult.Failure("Path is null")
            : new BuildingResult.Success(new TreeGoToCommand(_path));
    }

    public SetArgumentResult SetSourcePath(string sourcePath)
    {
        if (_path is not null)
        {
            return new SetArgumentResult.Failure("Path is already set");
        }

        _path = sourcePath;
        return new SetArgumentResult.Success(this);
    }
}