using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.ConnectionParsers;

public sealed class ConnectParser : BaseParser
{
    private readonly IArgumentParser<ConnectCommandBuilder> _subChain;

    public ConnectParser(IArgumentParser<ConnectCommandBuilder> subChain)
    {
        _subChain = subChain;
    }

    public override ParseResult Parse(IEnumerator<string> iterator)
    {
        if (iterator.Current != "connect")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        var builder = new ConnectCommandBuilder();

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