using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.FileParsers;

public sealed class FileCopyParser : BaseParser
{
    private readonly IArgumentParser<FileCopyCommandBuilder> _subChain;

    public FileCopyParser(IArgumentParser<FileCopyCommandBuilder> subChain)
    {
        _subChain = subChain;
    }

    public override ParseResult Parse(IEnumerator<string> iterator)
    {
        if (iterator.Current != "copy")
        {
            return NextParser.Parse(iterator);
        }

        iterator.MoveNext();
        var builder = new FileCopyCommandBuilder();

        while (iterator.Current is not null)
        {
            bool handled = false;
            ParseResult parseResult = _subChain.Parse(iterator, builder);

            if (parseResult is ParseResult.Success)
            {
                handled = true;
            }
            else if (parseResult is ParseResult.CriticalFailure failure)
            {
                return new ParseResult.CriticalFailure(failure.Message);
            }

            if (!handled)
                return new ParseResult.CriticalFailure("Invalid argument.");
        }

        return new ParseResult.Success(builder);
    }
}