using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.PositionalArguments;

public sealed class DestinationPathArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>, IPositionalArgument<TBuilder>
    where TBuilder : ICommandBuilder, IDestinationPathBuilder
{
    public override ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current is null)
        {
            return NextParser.Parse(iterator, builder);
        }

        string destinationPath = iterator.Current;
        SetArgumentResult buildingResult = builder.SetDestinationPath(destinationPath);

        if (buildingResult is SetArgumentResult.Success)
        {
            iterator.MoveNext();
            return new ParseResult.Success(builder);
        }

        return NextParser.Parse(iterator, builder);
    }
}