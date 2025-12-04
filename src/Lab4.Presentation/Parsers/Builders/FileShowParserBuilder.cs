using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

public sealed class FileShowParserBuilder : BaseParserBuilder<FileShowCommandBuilder>
{
    public override ICommandParser Build()
    {
        return new FileShowParser(SubChainCommandsHead, SubChainArgumentsHead);
    }
}