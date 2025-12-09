using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public abstract class BaseTypeParser<TBuilder> : ITypeParser<TBuilder>
where TBuilder : ICommandBuilder
{
    private ITypeParser<TBuilder> _nextParser = new DefaultTypeParser<TBuilder>();

    public void AddNext(ITypeParser<TBuilder> parser)
    {
        if (_nextParser is not DefaultTypeParser<TBuilder>)
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