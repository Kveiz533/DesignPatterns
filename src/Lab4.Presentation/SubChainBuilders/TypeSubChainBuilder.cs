using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.SubChainBuilders;

public sealed class TypeSubChainBuilder<TBuilder>
    where TBuilder : ICommandBuilder
{
    private ITypeParser<TBuilder> _head = new DefaultTypeParser<TBuilder>();

    public TypeSubChainBuilder<TBuilder> AddType(ITypeParser<TBuilder> parser)
    {
        if (_head is DefaultTypeParser<TBuilder>)
        {
            _head = parser;
        }
        else
        {
            _head.AddNext(parser);
        }

        return this;
    }

    public ITypeParser<TBuilder> Build()
    {
        _head.AddNext(new DefaultTypeParser<TBuilder>());
        return _head;
    }
}