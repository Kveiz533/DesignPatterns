using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public abstract class BaseArgumentParser<TBuilder> : IArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder
{
    private readonly ITypeParser<TBuilder>? _subChainArgumentValues;

    private IArgumentParser<TBuilder>? _nextParser;

    protected BaseArgumentParser(ITypeParser<TBuilder>? subChainArgumentValues)
    {
        _subChainArgumentValues = subChainArgumentValues;
    }

    public void AddNext(IArgumentParser<TBuilder> parser)
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
        ParseResult identificationResult = ParseCore(iterator, builder);

        if (identificationResult is ParseResult.FailureWithParsing)
        {
            return _nextParser?.Parse(iterator, builder) ?? identificationResult;
        }

        if (_subChainArgumentValues is null)
        {
            return new ParseResult.FailureWithArguments("Type can not be null");
        }

        ParseResult res = _subChainArgumentValues.Parse(iterator, builder);

        if (res is ParseResult.FailureWithParsing)
        {
            return _nextParser?.Parse(iterator, builder) ?? res;
        }

        return res;
    }

    protected abstract ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder);
}