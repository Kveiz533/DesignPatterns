using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public interface ITypeParser<TBuilder>
{
    void AddNext(ITypeParser<TBuilder> parser);

    ParseResult Parse(IArgumentIterator iterator, TBuilder builder);
}