using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;

public sealed class NameArgumentParserBuilder<TBuilder> : BaseArgumentParserBuilder<TBuilder>
    where TBuilder : INameBuilder, ICommandBuilder
{
    public override IArgumentParser<TBuilder> Build()
    {
        return new NameArgumentParser<TBuilder>(SubChainArgumentValuesHead);
    }
}