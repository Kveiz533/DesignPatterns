using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConnectionCommands;

public sealed class ConnectCommand : ICommand
{
    private readonly string _address;
    private readonly IFileSystem _fileSystem;

    public ConnectCommand(string address, IFileSystem fileSystem)
    {
        _address = address;
        _fileSystem = fileSystem;
    }

    public CommandResult Execute(Session session)
    {
        if (session.IsConnected)
        {
            return new CommandResult.Failure("Already connected.");
        }

        if (!_fileSystem.DirectoryExists(_address))
        {
            return new CommandResult.Failure($"Directory '{_address}' does not exist or is not accessible.");
        }

        session.Connect(_fileSystem, _address);
        return new CommandResult.Success();
    }
}