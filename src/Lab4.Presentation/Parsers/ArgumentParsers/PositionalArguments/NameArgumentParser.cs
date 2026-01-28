using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.PositionalArguments;

public sealed class NameArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>
    where TBuilder : ICommandBuilder, INameBuilder
{
    public override ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current is null)
        {
            return new ParseResult.Failure("Not enough arguments.");
        }

        string name = iterator.Current;
        SetArgumentResult buildingResult = builder.SetName(name);

        if (buildingResult is SetArgumentResult.Failure)
        {
            return CallNext(iterator, builder);
        }

        iterator.MoveNext();
        return new ParseResult.Success(builder);
    }
}