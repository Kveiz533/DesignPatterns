namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.TreeParsers;

public sealed class TreeParser : BaseParser
{
    private readonly ICommandParser _subChain;

    public TreeParser(ICommandParser subChain)
    {
        _subChain = subChain;
    }

    protected override ParseResult ParseCore(IEnumerator<string> iterator)
    {
        if (iterator.Current != "tree")
            return new ParseResult.Failure("Not tree command");

        iterator.MoveNext();
        return _subChain.Parse(iterator);
    }
}