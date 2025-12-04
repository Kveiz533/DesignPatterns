using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public abstract class BaseTypeParser<TBuilder> : ITypeParser<TBuilder>
where TBuilder : ICommandBuilder
{
    private ITypeParser<TBuilder>? _nextParser;

    public void AddNext(ITypeParser<TBuilder> parser)
    {
        if (_nextParser is not null)
        {
            _nextParser.AddNext(parser);
        }
        else
        {
            _nextParser = parser;
        }
    }

    public ParseResult Parse(IArgumentIterator iterator, TBuilder builder)
    {
        ParseResult parseResult = ParseCore(iterator, builder);

        if (parseResult is ParseResult.FailureWithParsing)
        {
            return _nextParser?.Parse(iterator, builder) ?? parseResult;
        }

        return parseResult;
    }

    protected abstract ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder);
}