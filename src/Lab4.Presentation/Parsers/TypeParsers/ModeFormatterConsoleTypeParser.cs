using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public class ModeFormatterConsoleTypeParser<TBuilder> : BaseTypeParser<TBuilder>
where TBuilder : ICommandBuilder, IModeFormatterBuilder
{
    protected override ParseResult ParseCore(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current is null)
        {
            return new ParseResult.CriticalFailure("Too few arguments");
        }

        string formatter = iterator.Current;

        if (formatter != "console")
        {
            return new ParseResult.CriticalFailure("Formatter not defined");
        }

        SetArgumentResult buildingResult = builder.SetModePrinter(new ConsoleFormatter());

        if (buildingResult is SetArgumentResult.Success)
        {
            return new ParseResult.Success(builder);
        }

        return new ParseResult.CriticalFailure("Arguments error");
    }
}