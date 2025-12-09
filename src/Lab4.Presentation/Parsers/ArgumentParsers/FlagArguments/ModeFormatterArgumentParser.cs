using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.FlagArguments;

public sealed class ModeFormatterArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>, IFlagArgument<TBuilder>
    where TBuilder : IModeFormatterBuilder, ICommandBuilder
{
    private readonly ITypeParser<TBuilder> _subChain;

    public ModeFormatterArgumentParser(ITypeParser<TBuilder> subChain)
    {
        _subChain = subChain;
    }

    protected override ParseResult ParseCore(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current != "-m")
        {
            return new ParseResult.Failure("Not mode flag");
        }

        iterator.MoveNext();

        if (iterator.Current is null)
        {
            return new ParseResult.CriticalFailure("Too few arguments");
        }

        ParseResult resultType = _subChain.Parse(iterator, builder);

        if (resultType is ParseResult.Success)
        {
            iterator.MoveNext();
            return new ParseResult.Success(builder);
        }

        return new ParseResult.CriticalFailure("Arguments error");
    }
}