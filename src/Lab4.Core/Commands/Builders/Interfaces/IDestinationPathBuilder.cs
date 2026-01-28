using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

public interface IDestinationPathBuilder : ICommandBuilder
{
    SetArgumentResult SetDestinationPath(string destinationPath);
}