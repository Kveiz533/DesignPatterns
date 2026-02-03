using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;

public sealed class ConnectCommandBuilder : ISourcePathBuilder, IModeFileSystemBuilder
{
    private string? _address;
    private IFileSystem? _fileSystem;

    public BuildingResult Build()
    {
        _fileSystem ??= new LocalFileSystem();

        return _address is null
            ? new BuildingResult.Failure("Address or Mode cannot be null.")
            : new BuildingResult.Success(new ConnectCommand(_address, _fileSystem));
    }

    public SetArgumentResult SetSourcePath(string sourcePath)
    {
        if (_address is not null)
        {
            return new SetArgumentResult.Failure("Address is already set.");
        }

        _address = sourcePath;
        return new SetArgumentResult.Success(this);
    }

    public SetArgumentResult SetModeFileSystem(IFileSystem fileSystem)
    {
        if (_fileSystem is not null)
        {
            return new SetArgumentResult.Failure("Mode is already set.");
        }

        _fileSystem = fileSystem;
        return new SetArgumentResult.Success(this);
    }
}