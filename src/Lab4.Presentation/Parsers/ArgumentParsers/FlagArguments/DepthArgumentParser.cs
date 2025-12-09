using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public sealed class DepthArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>, IFlagArgument
    where TBuilder : IDepthBuilder, ICommandBuilder
{
    public DepthArgumentParser(ITypeParser<TBuilder>? subChainArgumentValues) : base(subChainArgumentValues) { }

    protected override ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        if (iterator.Current() != "-d")
        {
            return new ParseResult.FailureWithParsing("Depth not defined");
        }

        iterator.MoveNext();
        return new ParseResult.Success(builder);
    }
}