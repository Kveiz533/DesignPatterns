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

    protected override ParseResult ParseCore(IEnumerator<string> iterator)
    {
        if (iterator.Current != "connect")
            return new ParseResult.Failure("Not connect command.");

        iterator.MoveNext();
        var builder = new ConnectCommandBuilder();

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