namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public interface ITypeParser<TBuilder>
{
    void AddNext(ITypeParser<TBuilder> parser);

    ParseResult Parse(IEnumerator<string> iterator, TBuilder builder);
}