namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public interface ITypeParser<TBuilder>
{
    ITypeParser<TBuilder> AddNext(ITypeParser<TBuilder> parser);

    ParseResult Parse(IEnumerator<string> iterator, TBuilder builder);
}