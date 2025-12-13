using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public abstract class BaseTypeParser<TBuilder> : ITypeParser<TBuilder>
where TBuilder : ICommandBuilder
{
    protected ITypeParser<TBuilder> NextParser { get; private set; } = new DefaultTypeParser<TBuilder>();

    public void AddNext(ITypeParser<TBuilder> parser)
    {
        if (NextParser is not DefaultTypeParser<TBuilder>)
        {
            NextParser.AddNext(parser);
        }
        else
        {
            NextParser = parser;
        }
    }

    public abstract ParseResult Parse(IEnumerator<string> iterator, TBuilder builder);
}