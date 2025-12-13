using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public abstract class BaseArgumentParser<TBuilder> : IArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder
{
    protected IArgumentParser<TBuilder> NextParser { get; private set; } = new DefaultArgumentParser<TBuilder>();

    public void AddNext(IArgumentParser<TBuilder> parser)
    {
        if (NextParser is not DefaultArgumentParser<TBuilder>)
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