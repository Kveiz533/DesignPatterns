using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;

public sealed class DestinationPathArgumentParserBuilder<TBuilder> : BaseArgumentParserBuilder<TBuilder>
    where TBuilder : IDestinationPathBuilder, ICommandBuilder
{
    public override IArgumentParser<TBuilder> Build()
    {
        return new DestinationPathArgumentParser<TBuilder>(SubChainArgumentValuesHead);
    }
}