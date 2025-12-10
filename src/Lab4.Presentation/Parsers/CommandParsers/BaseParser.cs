namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public abstract class BaseParser : ICommandParser
{
    private ICommandParser NextParser { get; set; } = new DefaultCommandParser();

    public void AddNext(ICommandParser nextParser)
    {
        if (NextParser is not DefaultCommandParser)
        {
            NextParser.AddNext(nextParser);
        }
        else
        {
            NextParser = nextParser;
        }
    }

    public ParseResult Parse(IEnumerator<string> iterator)
    {
        ParseResult result = ParseCore(iterator);

        if (result is ParseResult.Failure)
        {
            return NextParser.Parse(iterator);
        }

        return result;
    }

    protected abstract ParseResult ParseCore(IEnumerator<string> iterator);
}