using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

public interface IParserBuilder<TBuilder> where TBuilder : ICommandBuilder
{
    IParserBuilder<TBuilder> AddCommand(ICommandParser parser);

    IParserBuilder<TBuilder> AddPositional(IArgumentParser<TBuilder> parser);

    IParserBuilder<TBuilder> AddFlag(IArgumentParser<TBuilder> parser);

    ICommandParser Build();
}