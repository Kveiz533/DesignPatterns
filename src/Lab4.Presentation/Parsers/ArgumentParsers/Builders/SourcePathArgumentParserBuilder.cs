using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;

public sealed class SourcePathArgumentParserBuilder<TBuilder> : BaseArgumentParserBuilder<TBuilder>
    where TBuilder : ISourcePathBuilder, ICommandBuilder
{
    public override IArgumentParser<TBuilder> Build()
    {
        return new SourcePathArgumentParser<TBuilder>(SubChainArgumentValuesHead);
    }
}