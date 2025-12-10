namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class DefaultCommandParser : ICommandParser
{
    public ParseResult Parse(IEnumerator<string> iterator)
    {
        return new ParseResult.CriticalFailure("Reach end of subChain");
    }

    public void AddNext(ICommandParser nextParser) { }
}