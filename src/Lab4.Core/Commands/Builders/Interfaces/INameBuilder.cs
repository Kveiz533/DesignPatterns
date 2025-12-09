using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

public interface INameBuilder : ICommandBuilder
{
    SetArgumentResult SetName(string name);
}