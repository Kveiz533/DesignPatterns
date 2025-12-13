using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public abstract class BaseArgumentParser<TBuilder> : IArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder
{
    private IArgumentParser<TBuilder>? _nextParser;

    public IArgumentParser<TBuilder> AddNext(IArgumentParser<TBuilder> parser)
    {
        if (_nextParser is not null)
        {
            _nextParser.AddNext(parser);
        }
        else
        {
            _nextParser = parser;
        }

        return this;
    }

    public abstract ParseResult Parse(IEnumerator<string> iterator, TBuilder builder);

    protected ParseResult CallNext(IEnumerator<string> iterator, TBuilder builder)
    {
        return _nextParser?.Parse(iterator, builder) ?? new ParseResult.Failure("Wrong command");
    }
}