using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

public abstract class BaseParserBuilder<TBuilder> : IParserBuilder<TBuilder>
    where TBuilder : ICommandBuilder
{
    protected ICommandParser? SubChainCommandsHead { get; private set; }

    protected IArgumentParser<TBuilder>? SubChainArgumentsHead { get; private set; }

    private ICommandParser? SubChainCommandsTail { get; set; }

    private IArgumentParser<TBuilder>? SubChainArgumentsTail { get; set; }

    public void AddCommand(ICommandParser parser)
    {
        if (SubChainCommandsHead is null)
        {
            SubChainCommandsHead = parser;
        }
        else
        {
            SubChainCommandsTail?.AddNext(parser);
        }

        SubChainCommandsTail = parser;
    }

    public void AddPositional(IArgumentParser<TBuilder> parser)
    {
        if (SubChainArgumentsTail is null)
        {
            SubChainArgumentsHead = parser;
        }
        else
        {
            SubChainArgumentsTail.AddNext(parser);
        }

        SubChainArgumentsTail = parser;
    }

    public void AddFlag(IArgumentParser<TBuilder> parser)
    {
        if (SubChainArgumentsHead is null)
        {
            SubChainArgumentsHead = parser;
            SubChainArgumentsTail = parser;
        }
        else
        {
            parser.AddNext(SubChainArgumentsHead);
            SubChainArgumentsHead = parser;
        }
    }

    public abstract ICommandParser Build();
}