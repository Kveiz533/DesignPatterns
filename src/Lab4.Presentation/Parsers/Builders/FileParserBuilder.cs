using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

public sealed class FileParserBuilder : BaseParserBuilder<FileCommandBuilder>
{
    public override ICommandParser Build()
    {
        return new FileParser(SubChainCommandsHead, SubChainArgumentsHead);
    }
}