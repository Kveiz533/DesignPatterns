using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

public sealed class ModeFileSystemLocalTypeParser<TBuilder> : BaseTypeParser<TBuilder>
where TBuilder : ICommandBuilder, IModeFileSystemBuilder
{
    protected override ParseResult ParseCore(IEnumerator<string> iterator, TBuilder builder)
    {
        if (iterator.Current is null)
        {
            return new ParseResult.CriticalFailure("Too few arguments.");
        }

        string fileSystem = iterator.Current;

        if (fileSystem != "local")
        {
            return new ParseResult.CriticalFailure("FileSystem not defined.");
        }

        SetArgumentResult buildingResult = builder.SetModeFileSystem(new LocalFileSystem());

        if (buildingResult is SetArgumentResult.Success)
        {
            return new ParseResult.Success(builder);
        }

        return new ParseResult.CriticalFailure("Arguments error.");
    }
}