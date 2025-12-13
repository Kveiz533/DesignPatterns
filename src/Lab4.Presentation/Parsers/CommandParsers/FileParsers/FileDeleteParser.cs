using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.FileParsers;

public sealed class FileDeleteParser : BaseParser
{
    private readonly IArgumentParser<FileDeleteCommandBuilder> _subChain;

    public FileDeleteParser(IArgumentParser<FileDeleteCommandBuilder> subChain)
    {
        _subChain = subChain;
    }

    public override ParseResult Parse(IEnumerator<string> iterator)
    {
        if (iterator.Current != "delete")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        var builder = new FileDeleteCommandBuilder();

        while (iterator.Current is not null)
        {
            ParseResult parseResult = _subChain.Parse(iterator, builder);

            if (parseResult is ParseResult.Failure failure)
            {
                return new ParseResult.Failure(failure.Message);
            }
        }

        return new ParseResult.Success(builder);
    }
}