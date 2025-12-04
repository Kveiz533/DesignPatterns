using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public abstract class BaseArgumentParser<TBuilder> : IArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder
{
    private IArgumentParser<TBuilder>? _nextParser;

    // protected IArgumentParser<TBuilder>? SubChainArgumentValues { get; }

    // protected BaseArgumentParser(IArgumentParser<TBuilder>? valueChain = null)
    // {
    //     SubChainArgumentValues = valueChain;
    // }
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

    public ParseResult TryParse(IArgumentIterator iterator, TBuilder builder)
    {
        ParseResult result = TryParseCore(iterator, builder);

        if (result is ParseResult.FailureWithParsing)
        {
            return _nextParser?.TryParse(iterator, builder) ?? result;
        }

        return result;
    }

    protected abstract ParseResult TryParseCore(IArgumentIterator iterator, TBuilder builder);
}