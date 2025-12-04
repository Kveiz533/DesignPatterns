using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;

public interface IArgumentParserBuilder<TBuilder>
{
    IArgumentParserBuilder<TBuilder> AddAlias(ITypeParser<TBuilder> typeParser);

    IArgumentParserBuilder<TBuilder> AddValueType(ITypeParser<TBuilder> typeParser);

    IArgumentParser<TBuilder> Build();
}