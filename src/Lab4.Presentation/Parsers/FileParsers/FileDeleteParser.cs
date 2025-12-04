using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

public sealed class FileDeleteParser : BaseParser<FileDeleteCommandBuilder>
{
    public FileDeleteParser(
        ICommandParser? subChainCommands,
        IArgumentParser<FileDeleteCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "delete";

    protected override FileDeleteCommandBuilder CreateBuilder()
    {
        return new FileDeleteCommandBuilder();
    }
}