using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.FlagArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.PositionalArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.SubChainBuilders;

public class ArgumentSubChainBuilder<TBuilder>
where TBuilder : ICommandBuilder
{
    private IArgumentParser<TBuilder> _head = new DefaultArgumentParser<TBuilder>();

    public ArgumentSubChainBuilder<TBuilder> AddFlag(IFlagArgument<TBuilder> parser)
    {
        if (_head is not DefaultArgumentParser<TBuilder>)
        {
            parser.AddNext(_head);
        }

        _head = parser;

        return this;
    }

    public ArgumentSubChainBuilder<TBuilder> AddPositionalArgument(IPositionalArgument<TBuilder> parser)
    {
        if (_head is DefaultArgumentParser<TBuilder>)
        {
            _head = parser;
        }
        else
        {
            _head.AddNext(parser);
        }

        return this;
    }

    public IArgumentParser<TBuilder> Build()
    {
        _head.AddNext(new DefaultArgumentParser<TBuilder>());
        return _head;
    }
}