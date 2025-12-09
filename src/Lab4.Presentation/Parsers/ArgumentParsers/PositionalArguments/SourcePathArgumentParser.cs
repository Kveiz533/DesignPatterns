using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.PositionalArguments;

public sealed class SourcePathArgumentParser<TBuilder> : BaseArgumentParser<TBuilder>, IPositionalArgument<TBuilder>
    where TBuilder : ICommandBuilder, ISourcePathBuilder
{
    protected override ParseResult ParseCore(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current is null)
        {
            return new ParseResult.Failure("Too few arguments");
        }

        string name = iterator.Current;
        SetArgumentResult buildingResult = builder.SetSourcePath(name);

        if (buildingResult is SetArgumentResult.Success)
        {
            iterator.MoveNext();
            return new ParseResult.Success(builder);
        }

        return new ParseResult.Failure("Arguments error");
    }
}