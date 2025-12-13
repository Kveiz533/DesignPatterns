namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

public abstract class BaseParser : ICommandParser
{
    protected ICommandParser NextParser { get; private set; } = new DefaultCommandParser();

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

    public abstract ParseResult Parse(IEnumerator<string> iterator);
}