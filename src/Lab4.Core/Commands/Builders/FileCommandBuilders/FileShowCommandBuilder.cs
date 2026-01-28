using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;

public sealed class FileShowCommandBuilder : ISourcePathBuilder, IModeFormatterBuilder
{
    private string? _path;
    private IFormatter? _formatter;

    public BuildingResult Build()
    {
        return _path is null || _formatter is null
            ? new BuildingResult.Failure("Path or Mode cannot be null.")
            : new BuildingResult.Success(new FileShowCommand(_path, _formatter));
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

    public SetArgumentResult SetModePrinter(IFormatter formatter)
    {
        if (_formatter is not null)
        {
            return new SetArgumentResult.Failure("Mode is already set.");
        }

        _formatter = formatter;
        return new SetArgumentResult.Success(this);
    }
}