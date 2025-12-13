using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConnectionCommands;

public sealed class DisconnectCommand : ICommand
{
    public CommandResult Execute(Session session)
    {
        return session.Disconnect() ?
            new CommandResult.Success() :
            new CommandResult.Failure("Already disconnected.");
    }
}