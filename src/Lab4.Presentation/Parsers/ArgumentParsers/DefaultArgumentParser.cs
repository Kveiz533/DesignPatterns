using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.FlagArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.PositionalArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public class DefaultArgumentParser<TBuilder> : IFlagArgument<TBuilder>, IPositionalArgument<TBuilder>
where TBuilder : ICommandBuilder
{
    public void AddNext(IArgumentParser<TBuilder> parser) { }

    public ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        return new ParseResult.Failure("Reach end of subChain");
    }
}