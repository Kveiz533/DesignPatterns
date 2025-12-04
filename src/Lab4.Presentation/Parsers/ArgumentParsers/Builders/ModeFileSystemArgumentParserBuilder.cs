using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;

public sealed class ModeFileSystemArgumentParserBuilder<TBuilder> : BaseArgumentParserBuilder<TBuilder>
    where TBuilder : IModeFileSystemBuilder, ICommandBuilder
{
    public override IArgumentParser<TBuilder> Build()
    {
        return new ModeFileSystemArgumentParser<TBuilder>(SubChainArgumentValuesHead);
    }
}