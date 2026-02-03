namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public interface IArgumentParser<TBuilder>
{
    IArgumentParser<TBuilder> AddNext(IArgumentParser<TBuilder> parser);

    ParseResult Parse(IEnumerator<string> iterator, TBuilder builder);
}