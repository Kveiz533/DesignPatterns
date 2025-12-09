using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.SubChainBuilders;

public class ParserSubChainBuilder
{
    private ICommandParser _head = new DefaultCommandParser();

    public ParserSubChainBuilder AddParser(ICommandParser parser)
    {
        if (_head is not DefaultCommandParser)
        {
            parser.AddNext(_head);
        }

        _head = parser;

        return this;
    }

    public ICommandParser Build()
    {
        _head.AddNext(new DefaultCommandParser());
        return _head;
    }
}