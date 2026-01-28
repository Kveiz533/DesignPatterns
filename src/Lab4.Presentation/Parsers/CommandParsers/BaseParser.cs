namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

public abstract class BaseParser : ICommandParser
{
    private ICommandParser? _nextParser;

    public ICommandParser AddNext(ICommandParser nextParser)
    {
        if (_nextParser is not null)
        {
            _nextParser.AddNext(nextParser);
        }
        else
        {
            _nextParser = nextParser;
        }

        return this;
    }

    public abstract ParseResult Parse(IEnumerator<string> iterator);

    protected ParseResult CallNext(IEnumerator<string> iterator)
    {
        return _nextParser?.Parse(iterator) ?? new ParseResult.Failure("Wrong command");
    }
}