using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;

public sealed class FileRenameCommandBuilder : ISourcePathBuilder, INameBuilder
{
    private string? _path;
    private string? _name;

    public BuildingResult Build()
    {
        return _path is null || _name is null
            ? new BuildingResult.Failure("Path or Name cannot be null")
            : new BuildingResult.Success(new FileRenameCommand(_path, _name));
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

    public SetArgumentResult SetName(string name)
    {
        if (_name is not null)
        {
            return new SetArgumentResult.Failure("Name is already set");
        }

        _name = name;
        return new SetArgumentResult.Success(this);
    }
}