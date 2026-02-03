using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public class DepthTypeParser<TBuilder> : BaseTypeParser<TBuilder>
    where TBuilder : ICommandBuilder, IDepthBuilder
{
    public override ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        string depth = iterator.Current;

        if (!int.TryParse(depth, out int parsedDepth) || parsedDepth <= 0)
        {
            return CallNext(iterator, builder);
        }

        SetArgumentResult buildingResult = builder.SetDepth(parsedDepth);

        return buildingResult is SetArgumentResult.Success
            ? new ParseResult.Success(builder)
            : new ParseResult.Failure("Arguments error.");
    }
}