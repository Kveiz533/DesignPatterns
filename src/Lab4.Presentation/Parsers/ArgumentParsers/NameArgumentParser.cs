using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public sealed class NameArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder, INameBuilder
{
    protected override ParseResult TryParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        string? name = iterator.Current();

        if (name is null)
        {
            return new ParseResult.FailureWithArguments("Name can not be null");
        }

        SetArgumentResult setArgumentResult = builder.SetName(name);

        switch (setArgumentResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithParsing(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Unknown error setting Name");
        }
    }
}