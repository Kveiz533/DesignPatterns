namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public class DefaultTypeParser<TBuilder> : ITypeParser<TBuilder>
{
    public void AddNext(ITypeParser<TBuilder> parser) { }

    public ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        return new ParseResult.CriticalFailure("Reach end of subChain");
    }
}