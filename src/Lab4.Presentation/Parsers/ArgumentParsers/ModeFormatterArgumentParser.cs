using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public sealed class ModeFormatterArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>
    where TBuilder : IModeFormatterBuilder, ICommandBuilder
{
    protected override ParseResult TryParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        if (iterator.Current() != "-m")
        {
            return new ParseResult.FailureWithParsing("Flag is not -d");
        }

        iterator.MoveNext();
        string? modeFormatter = iterator.Current();

        if (modeFormatter is null)
        {
            return new ParseResult.FailureWithArguments("Mode can not be null");
        }

        SetArgumentResult setArgumentResult = builder.SetModePrinter(new LocalFormatter());

        switch (setArgumentResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithArguments(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Unknown error setting ModePrinter");
        }
    }
}