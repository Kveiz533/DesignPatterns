using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.FlagArguments;

public sealed class ModeFileSystemArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>
    where TBuilder : IModeFileSystemBuilder, ICommandBuilder
{
    private readonly ITypeParser<TBuilder> _subChain;

    public ModeFileSystemArgumentParser(ITypeParser<TBuilder> subChain)
    {
        _subChain = subChain;
    }

    public override ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current != "-m")
        {
            return CallNext(iterator, builder);
        }

        iterator.MoveNext();

        if (iterator.Current is null)
        {
            return new ParseResult.Failure("Too few arguments");
        }

        ParseResult resultType = _subChain.Parse(iterator, builder);

        if (resultType is ParseResult.Failure)
        {
            return CallNext(iterator, builder);
        }

        iterator.MoveNext();
        return new ParseResult.Success(builder);
    }
}