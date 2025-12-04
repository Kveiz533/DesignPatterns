using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

public sealed class FileMoveParser : BaseParser<FileMoveCommandBuilder>
{
    public FileMoveParser(
        ICommandParser? subChainCommands,
        IArgumentParser<FileMoveCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "move";

    protected override FileMoveCommandBuilder CreateBuilder()
    {
        return new FileMoveCommandBuilder();
    }
}