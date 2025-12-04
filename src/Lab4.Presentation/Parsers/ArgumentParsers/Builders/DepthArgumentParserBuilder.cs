using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;

public sealed class DepthArgumentParserBuilder<TBuilder> : BaseArgumentParserBuilder<TBuilder>
where TBuilder : IDepthBuilder, ICommandBuilder
{
    public override IArgumentParser<TBuilder> Build()
    {
        return new DepthArgumentParser<TBuilder>(SubChainArgumentValuesHead);
    }
}