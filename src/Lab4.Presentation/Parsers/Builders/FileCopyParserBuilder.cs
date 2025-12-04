using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

public sealed class FileCopyParserBuilder : BaseParserBuilder<FileCopyCommandBuilder>
{
    public override ICommandParser Build()
    {
        return new FileCopyParser(SubChainCommandsHead, SubChainArgumentsHead);
    }
}