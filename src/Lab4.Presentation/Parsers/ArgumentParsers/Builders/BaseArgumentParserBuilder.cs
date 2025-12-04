using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;

public abstract class BaseArgumentParserBuilder<TBuilder> : IArgumentParserBuilder<TBuilder>
    where TBuilder : ICommandBuilder
{
    protected ITypeParser<TBuilder>? SubChainArgumentValuesHead { get; private set; }

    private ITypeParser<TBuilder>? SubChainArgumentValuesTail { get; set; }

    public IArgumentParserBuilder<TBuilder> AddAlias(ITypeParser<TBuilder> typeParser)
    {
        if (SubChainArgumentValuesHead is null)
        {
            SubChainArgumentValuesHead = typeParser;
            SubChainArgumentValuesTail = typeParser;
        }
        else
        {
            typeParser.AddNext(SubChainArgumentValuesHead);
            SubChainArgumentValuesHead = typeParser;
        }

        return this;
    }

    public IArgumentParserBuilder<TBuilder> AddValueType(ITypeParser<TBuilder> typeParser)
    {
        if (SubChainArgumentValuesTail is null)
        {
            SubChainArgumentValuesHead = typeParser;
        }
        else
        {
            SubChainArgumentValuesTail.AddNext(typeParser);
        }

        SubChainArgumentValuesTail = typeParser;
        return this;
    }

    public abstract IArgumentParser<TBuilder> Build();
}