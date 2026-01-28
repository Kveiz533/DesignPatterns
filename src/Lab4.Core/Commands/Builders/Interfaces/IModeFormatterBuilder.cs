using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

public interface IModeFormatterBuilder : ICommandBuilder
{
    SetArgumentResult SetModePrinter(IFormatter formatter);
}