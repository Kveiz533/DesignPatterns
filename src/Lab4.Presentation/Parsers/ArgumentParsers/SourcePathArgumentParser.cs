using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public sealed class SourcePathArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder, ISourcePathBuilder
{
    protected override ParseResult TryParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        string? sourcePath = iterator.Current();

        if (sourcePath is null)
        {
            return new ParseResult.FailureWithArguments("SourcePath can not be null");
        }

        SetArgumentResult setArgumentResult = builder.SetSourcePath(sourcePath);

        switch (setArgumentResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithParsing(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Unknown error setting SourcePath");
        }
    }
}