using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TreeParsers;

public sealed class TreeListParser : BaseParser<TreeListCommandBuilder>
{
    public TreeListParser(
        ICommandParser? subChainCommands,
        IArgumentParser<TreeListCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "list";

    protected override TreeListCommandBuilder CreateBuilder()
    {
        return new TreeListCommandBuilder();
    }
}