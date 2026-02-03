using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.TreeParsers;

public sealed class TreeListParser : BaseParser
{
    private readonly IArgumentParser<TreeListCommandBuilder> _subChain;

    public TreeListParser(IArgumentParser<TreeListCommandBuilder> subChain)
    {
        _subChain = subChain;
    }

    public override ParseResult Parse(IEnumerator<string> iterator)
    {
        if (iterator.Current != "list")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        var builder = new TreeListCommandBuilder();

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