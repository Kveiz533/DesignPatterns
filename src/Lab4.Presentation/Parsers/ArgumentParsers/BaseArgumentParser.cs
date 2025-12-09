using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public abstract class BaseArgumentParser<TBuilder> : IArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder
{
    private IArgumentParser<TBuilder> _nextParser = new DefaultArgumentParser<TBuilder>();

    public void AddNext(IArgumentParser<TBuilder> parser)
    {
        if (_nextParser is not DefaultArgumentParser<TBuilder>)
        {
            _nextParser.AddNext(parser);
        }
        else
        {
            _nextParser = parser;
        }
    }

    public ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        ParseResult result = ParseCore(iterator, builder);

        if (result is ParseResult.Failure)
        {
            return _nextParser.Parse(iterator, builder);
        }

        return result;
    }

    protected abstract ParseResult ParseCore(IEnumerator<string> iterator, TBuilder builder);
}