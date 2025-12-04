using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

public sealed class FileParser : BaseParser<FileCommandBuilder>
{
    public FileParser(
        ICommandParser? subChainCommands,
        IArgumentParser<FileCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "file";

    protected override FileCommandBuilder CreateBuilder()
    {
        return new FileCommandBuilder();
    }
}