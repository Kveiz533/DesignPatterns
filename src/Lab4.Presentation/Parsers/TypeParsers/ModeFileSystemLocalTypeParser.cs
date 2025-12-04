using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public sealed class ModeFileSystemLocalTypeParser<TBuilder> : BaseTypeParser<TBuilder>
where TBuilder : ICommandBuilder, IModeFileSystemBuilder
{
    protected override ParseResult ParseCore(IArgumentIterator iterator, TBuilder builder)
    {
        string? fileSystem = iterator.Current();

        if (fileSystem != "local")
        {
            return new ParseResult.FailureWithParsing("FileSystem not defined");
        }

        SetArgumentResult buildingResult = builder.SetModeFileSystem(new LocalFileSystem());

        switch (buildingResult)
        {
            case SetArgumentResult.Success:
                iterator.MoveNext();
                return new ParseResult.Success(builder);

            case SetArgumentResult.Failure failure:
                return new ParseResult.FailureWithArguments(failure.Message);

            default:
                return new ParseResult.FailureWithArguments("Wrong fileSystem type");
        }
    }
}