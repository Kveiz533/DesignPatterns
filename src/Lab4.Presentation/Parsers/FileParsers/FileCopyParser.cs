using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

public sealed class FileCopyParser : BaseParser<FileCopyCommandBuilder>
{
    public FileCopyParser(
        ICommandParser? subChainCommands,
        IArgumentParser<FileCopyCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "copy";

    protected override FileCopyCommandBuilder CreateBuilder()
    {
        return new FileCopyCommandBuilder();
    }
}