using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public sealed class ModeFileSystemLocalTypeParser<TBuilder> : BaseTypeParser<TBuilder>
where TBuilder : ICommandBuilder, IModeFileSystemBuilder
{
    public override ParseResult Parse(IEnumerator<string> iterator, TBuilder builder)
    {
        string fileSystem = iterator.Current;

        if (fileSystem != "local")
        {
            return CallNext(iterator, builder);
        }

        SetArgumentResult buildingResult = builder.SetModeFileSystem(new LocalFileSystem());

        return buildingResult is SetArgumentResult.Success
            ? new ParseResult.Success(builder)
            : new ParseResult.Failure("Arguments error.");
    }
}