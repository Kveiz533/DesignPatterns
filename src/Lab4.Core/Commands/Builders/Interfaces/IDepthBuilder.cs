using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

public interface IDepthBuilder : ICommandBuilder
{
    SetArgumentResult SetDepth(int depth);
}