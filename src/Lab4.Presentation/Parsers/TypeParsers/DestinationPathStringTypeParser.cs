using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public sealed class DestinationPathStringTypeParser<TBuilder> : BaseTypeParser<TBuilder>
where TBuilder : ICommandBuilder, IDestinationPathBuilder
{
    protected override ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        string? destinationPath = iterator.Current();

        if (destinationPath is null)
        {
            return new ParseResult.FailureWithParsing("DestinationPath not defined");
        }

        SetArgumentResult buildingResult = builder.SetDestinationPath(destinationPath);

        switch (buildingResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithParsing(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Wrong destinationPath type");
        }
    }
}