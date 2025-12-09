using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

public interface IPrintingParamsBuilder : ICommandBuilder
{
    SetArgumentResult SetIndentSymbol(char indentSymbol);

    SetArgumentResult SetDirectorySymbol(string directorySymbol);

    SetArgumentResult SetFileSymbol(string fileSymbol);
}