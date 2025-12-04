using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TreeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

public sealed class TreeListParserBuilder : BaseParserBuilder<TreeListCommandBuilder>
{
    public override ICommandParser Build()
    {
        return new TreeListParser(SubChainCommandsHead, SubChainArgumentsHead);
    }
}