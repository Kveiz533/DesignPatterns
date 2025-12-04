using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public class ModeFormatterConsoleTypeParser<TBuilder> : BaseTypeParser<TBuilder>
where TBuilder : ICommandBuilder, IModeFormatterBuilder
{
    protected override ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        string? fileSystem = iterator.Current();

        if (fileSystem != "console")
        {
            return new ParseResult.FailureWithParsing("Formatter not defined");
        }

        SetArgumentResult buildingResult = builder.SetModePrinter(new LocalFormatter());

        switch (buildingResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithArguments(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Wrong formatter type");
        }
    }
}