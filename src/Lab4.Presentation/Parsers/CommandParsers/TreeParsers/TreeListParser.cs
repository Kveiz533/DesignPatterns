using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TreeParsers;

public sealed class TreeListParser : BaseParser
{
    private readonly IArgumentParser<TreeListCommandBuilder> _subChain;

    public TreeListParser(IArgumentParser<TreeListCommandBuilder> subChain)
    {
        _subChain = subChain;
    }

    protected override ParseResult ParseCore(IEnumerator<string> iterator)
    {
        if (iterator.Current != "list")
        {
            return new ParseResult.Failure("Not list command");
        }

        iterator.MoveNext();
        var builder = new TreeListCommandBuilder();

        while (iterator.Current is not null)
        {
            bool handled = false;

            if (_subChain is not null)
            {
                ParseResult parseResult = _subChain.Parse(iterator, builder);

                if (parseResult is ParseResult.Success)
                {
                    handled = true;
                }
                else if (parseResult is ParseResult.CriticalFailure failure)
                {
                    return new ParseResult.CriticalFailure(failure.Message);
                }
            }

            if (!handled)
            {
                return new ParseResult.CriticalFailure("Invalid argument");
            }
        }

        return new ParseResult.Success(builder);
    }
}