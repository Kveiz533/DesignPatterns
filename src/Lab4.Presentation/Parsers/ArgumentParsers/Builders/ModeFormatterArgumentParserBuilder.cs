using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;

public sealed class ModeFormatterArgumentParserBuilder<TBuilder> : BaseArgumentParserBuilder<TBuilder>
    where TBuilder : IModeFormatterBuilder, ICommandBuilder
{
    public override IArgumentParser<TBuilder> Build()
    {
        return new ModeFormatterArgumentParser<TBuilder>(SubChainArgumentValuesHead);
    }
}