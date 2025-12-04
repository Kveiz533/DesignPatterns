using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

public interface IParserBuilder<TBuilder> where TBuilder : ICommandBuilder
{
    void AddCommand(ICommandParser parser);

    void AddPositional(IArgumentParser<TBuilder> parser);

    void AddFlag(IArgumentParser<TBuilder> parser);

    ICommandParser Build();
}