using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

public sealed class FileShowParser : BaseParser<FileShowCommandBuilder>
{
    public FileShowParser(
        ICommandParser? subChainCommands,
        IArgumentParser<FileShowCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "show";

    protected override FileShowCommandBuilder CreateBuilder()
    {
        return new FileShowCommandBuilder();
    }
}