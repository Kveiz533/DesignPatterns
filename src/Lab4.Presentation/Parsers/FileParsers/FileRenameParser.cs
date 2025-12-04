using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

public sealed class FileRenameParser : BaseParser<FileRenameCommandBuilder>
{
    public FileRenameParser(
        ICommandParser? subChainCommands,
        IArgumentParser<FileRenameCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "rename";

    protected override FileRenameCommandBuilder CreateBuilder()
    {
        return new FileRenameCommandBuilder();
    }
}