using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TreeParsers;

public sealed class TreeGoToParser : BaseParser<TreeGoToCommandBuilder>
{
    public TreeGoToParser(
        ICommandParser? subChainCommands,
        IArgumentParser<TreeGoToCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "goto";

    protected override TreeGoToCommandBuilder CreateBuilder()
    {
        return new TreeGoToCommandBuilder();
    }
}