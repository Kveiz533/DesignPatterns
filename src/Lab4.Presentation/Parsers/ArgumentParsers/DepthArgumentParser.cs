using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public sealed class DepthArgumentParser<TBuilder> : BaseArgumentParser<TBuilder> where TBuilder : IDepthBuilder, ICommandBuilder
{
    // public DepthArgumentParser(IArgumentParser<TBuilder>? valueChain) : base(valueChain) { }
    protected override ParseResult TryParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        if (iterator.Current() != "-d")
        {
            return new ParseResult.FailureWithParsing("Flag is not -d");
        }

        iterator.MoveNext();
        string? depth = iterator.Current();

        if (depth is null)
        {
            return new ParseResult.FailureWithArguments("Depth can not be null");
        }

        SetArgumentResult setArgumentResult = builder.SetDepth(depth);

        switch (setArgumentResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithArguments(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Unknown error setting Depth");
        }
    }
}