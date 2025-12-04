using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public sealed class SourcePathStringTypeParser<TBuilder> : BaseTypeParser<TBuilder>
    where TBuilder : ICommandBuilder, ISourcePathBuilder
{
    protected override ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        string? sourcePath = iterator.Current();

        if (sourcePath is null)
        {
            return new ParseResult.FailureWithParsing("SourcePath not defined");
        }

        SetArgumentResult buildingResult = builder.SetSourcePath(sourcePath);

        switch (buildingResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithParsing(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Wrong sourcePath type");
        }
    }
}