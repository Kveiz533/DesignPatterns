using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TreeParsers;

public sealed class TreeParser : BaseParser<TreeCommandBuilder>
{
    public TreeParser(
        ICommandParser? subChainCommands,
        IArgumentParser<TreeCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "tree";

    protected override TreeCommandBuilder CreateBuilder()
    {
        return new TreeCommandBuilder();
    }
}