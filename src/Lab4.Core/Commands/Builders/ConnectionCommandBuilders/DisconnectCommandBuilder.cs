using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConnectionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;

public sealed class DisconnectCommandBuilder : ICommandBuilder
{
    public BuildingResult Build()
    {
        return new BuildingResult.Success(new DisconnectCommand());
    }
}