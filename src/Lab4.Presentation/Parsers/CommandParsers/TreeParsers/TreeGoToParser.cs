using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.TreeParsers;

public sealed class TreeGoToParser : BaseParser
{
    private readonly IArgumentParser<TreeGoToCommandBuilder> _subChain;

    public TreeGoToParser(IArgumentParser<TreeGoToCommandBuilder> subChain)
    {
        _subChain = subChain;
    }

    public override ParseResult Parse(IEnumerator<string> iterator)
    {
        if (iterator.Current != "goto")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        var builder = new TreeGoToCommandBuilder();

        while (iterator.Current is not null)
        {
            ParseResult parseResult = _subChain.Parse(iterator, builder);

            if (parseResult is ParseResult.Failure failure)
            {
                return new ParseResult.Failure(failure.Message);
            }
        }

        return new ParseResult.Success(builder);
    }
}