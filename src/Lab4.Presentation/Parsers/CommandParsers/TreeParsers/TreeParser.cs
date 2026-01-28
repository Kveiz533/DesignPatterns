namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.TreeParsers;

public sealed class TreeParser : BaseParser
{
    private readonly ICommandParser _subChain;

    public TreeParser(ICommandParser subChain)
    {
        _subChain = subChain;
    }

    public override ParseResult Parse(IEnumerator<string> iterator)
    {
        if (iterator.Current != "tree")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        return _subChain.Parse(iterator);
    }
}