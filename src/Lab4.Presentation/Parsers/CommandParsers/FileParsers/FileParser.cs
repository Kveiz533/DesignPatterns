namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.FileParsers;

public sealed class FileParser : BaseParser
{
    private readonly ICommandParser _subChain;

    public FileParser(ICommandParser subChain)
    {
        _subChain = subChain;
    }

    public override ParseResult Parse(IEnumerator<string> iterator)
    {
        if (iterator.Current != "file")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        return _subChain.Parse(iterator);
    }
}