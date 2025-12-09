using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.FlagArguments;

public sealed class DepthArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>, IFlagArgument<TBuilder>
    where TBuilder : IDepthBuilder, ICommandBuilder
{
    protected override ParseResult ParseCore(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current != "-d")
        {
            return new ParseResult.Failure("Not depth flag");
        }

        iterator.MoveNext();

        if (iterator.Current is null)
        {
            return new ParseResult.CriticalFailure("Too few arguments");
        }

        string depth = iterator.Current;

        if (!int.TryParse(depth, out int parsedDepth))
        {
            return new ParseResult.CriticalFailure("Depth must be an integer");
        }

        if (parsedDepth <= 0)
        {
            return new ParseResult.CriticalFailure("Depth must be a positive integer");
        }

        SetArgumentResult buildingResult = builder.SetDepth(parsedDepth);

        if (buildingResult is SetArgumentResult.Success)
        {
            iterator.MoveNext();
            return new ParseResult.Success(builder);
        }

        return new ParseResult.CriticalFailure("Arguments error");
    }
}