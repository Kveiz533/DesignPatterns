using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public class ModeFormatterConsoleTypeParser<TBuilder> : BaseTypeParser<TBuilder>
where TBuilder : ICommandBuilder, IModeFormatterBuilder
{
    public override ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        string formatter = iterator.Current;

        if (formatter != "console")
        {
            return CallNext(iterator, builder);
        }

        SetArgumentResult buildingResult = builder.SetModePrinter(new ConsoleFormatter());

        return buildingResult is SetArgumentResult.Success
            ? new ParseResult.Success(builder)
            : new ParseResult.Failure("Arguments error.");
    }
}