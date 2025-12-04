using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public sealed class SourcePathArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder, ISourcePathBuilder
{
    public SourcePathArgumentParser(ITypeParser<TBuilder>? subChainArgumentValues) : base(subChainArgumentValues) { }

    protected override ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        return new ParseResult.Success(builder);
    }
}