namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.FileParsers;

public sealed class FileParser : BaseParser
{
    private readonly ICommandParser _subChain;

    public FileParser(ICommandParser subChain)
    {
        _subChain = subChain;
    }

    protected override ParseResult ParseCore(IEnumerator<string> iterator)
    {
        if (iterator.Current != "file")
            return new ParseResult.Failure("Not file command.");

        iterator.MoveNext();
        return _subChain.Parse(iterator);
    }
}