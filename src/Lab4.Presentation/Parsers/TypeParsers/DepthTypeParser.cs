using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public class DepthTypeParser<TBuilder> : BaseTypeParser<TBuilder>
    where TBuilder : ICommandBuilder, IDepthBuilder
{
    public override ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current is null)
        {
            return new ParseResult.CriticalFailure("Too few arguments.");
        }

        string depth = iterator.Current;

        if (!int.TryParse(depth, out int parsedDepth))
        {
            return NextParser.Parse(iterator, builder);
        }

        if (parsedDepth <= 0)
        {
            return NextParser.Parse(iterator, builder);
        }

        SetArgumentResult buildingResult = builder.SetDepth(parsedDepth);

        if (buildingResult is SetArgumentResult.Success)
        {
            return new ParseResult.Success(builder);
        }

        return new ParseResult.CriticalFailure("Arguments error.");
    }
}