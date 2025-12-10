using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.FileParsers;

public sealed class FileRenameParser : BaseParser
{
    private readonly IArgumentParser<FileRenameCommandBuilder> _subChain;

    public FileRenameParser(IArgumentParser<FileRenameCommandBuilder> subChain)
    {
        _subChain = subChain;
    }

    protected override ParseResult ParseCore(IEnumerator<string> iterator)
    {
        if (iterator.Current != "rename")
            return new ParseResult.Failure("Not rename command.");

        iterator.MoveNext();
        var builder = new FileRenameCommandBuilder();

        while (iterator.Current is not null)
        {
            bool handled = false;

            if (_subChain is not null)
            {
                ParseResult parseResult = _subChain.Parse(iterator, builder);

                if (parseResult is ParseResult.Success)
                {
                    handled = true;
                }
                else if (parseResult is ParseResult.CriticalFailure failure)
                {
                    return new ParseResult.CriticalFailure(failure.Message);
                }
            }

            if (!handled)
                return new ParseResult.CriticalFailure("Invalid argument.");
        }

        return new ParseResult.Success(builder);
    }
}