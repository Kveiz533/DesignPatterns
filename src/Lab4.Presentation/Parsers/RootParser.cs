using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public sealed class RootParser : ICommandParser
{
    private readonly ICommandParser _subChainCommands;

    public RootParser(
        ICommandParser subChainCommands)
    {
        _subChainCommands = subChainCommands;
    }

    public ParseResult Parse(IArgumentIterator iterator)
    {
        if (iterator.Current() is null)
        {
            return new ParseResult.FailureWithParsing("Is not a command");
        }

        ParseResult result = _subChainCommands.Parse(iterator);
        return result;
    }

    public void AddNext(ICommandParser nextParser) { }
}