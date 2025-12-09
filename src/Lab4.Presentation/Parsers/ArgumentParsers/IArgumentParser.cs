namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public interface IArgumentParser<TBuilder>
{
    void AddNext(IArgumentParser<TBuilder> parser);

    ParseResult Parse(IEnumerator<string> iterator, TBuilder builder);
}