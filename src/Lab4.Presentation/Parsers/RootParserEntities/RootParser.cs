using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.RootParserEntities;

public sealed class RootParser
{
    private readonly ICommandParser _subChainCommands;

    public RootParser(ICommandParser subChainCommands)
    {
        _subChainCommands = subChainCommands;
    }

    public ParseResult Parse(IEnumerator<string> iterator)
    {
        iterator.MoveNext();
        if (iterator.Current is null)
            return new ParseResult.Failure("Is not a command.");

        ParseResult result = _subChainCommands.Parse(iterator);
        return result;
    }
}