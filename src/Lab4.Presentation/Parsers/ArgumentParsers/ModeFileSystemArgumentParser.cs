using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public sealed class ModeFileSystemArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>
    where TBuilder : IModeFileSystemBuilder, ICommandBuilder
{
    public ModeFileSystemArgumentParser(ITypeParser<TBuilder>? subChainArgumentValues) : base(subChainArgumentValues) { }

    protected override ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        if (iterator.Current() != "-m")
        {
            return new ParseResult.FailureWithParsing("ModeFileSystem not defined");
        }

        iterator.MoveNext();
        return new ParseResult.Success(builder);
    }
}