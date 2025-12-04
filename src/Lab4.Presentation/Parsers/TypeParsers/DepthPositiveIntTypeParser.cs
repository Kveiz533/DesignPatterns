using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public sealed class DepthPositiveIntTypeParser<TBuilder> : BaseTypeParser<TBuilder>
where TBuilder : ICommandBuilder, IDepthBuilder
{
    protected override ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        string? depth = iterator.Current();

        if (depth is null)
        {
            return new ParseResult.FailureWithParsing("FileSystem not defined");
        }

        if (!int.TryParse(depth, out int parsedDepth))
        {
            return new ParseResult.FailureWithArguments("Depth must be an integer");
        }

        if (parsedDepth <= 0)
        {
            return new ParseResult.FailureWithArguments("Depth must be a positive integer");
        }

        SetArgumentResult buildingResult = builder.SetDepth(parsedDepth);

        switch (buildingResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithArguments(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Wrong depth type");
        }
    }
}