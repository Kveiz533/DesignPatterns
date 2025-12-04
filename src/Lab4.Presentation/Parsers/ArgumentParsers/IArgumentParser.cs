using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public interface IArgumentParser<TBuilder>
{
    void AddNext(IArgumentParser<TBuilder> parser);

    ParseResult Parse(IArgumentIterator iterator, TBuilder builder);
}