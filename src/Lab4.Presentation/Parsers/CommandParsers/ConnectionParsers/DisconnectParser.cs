using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.ConnectionParsers;

public sealed class DisconnectParser : BaseParser
{
    protected override ParseResult ParseCore(IEnumerator<string> iterator)
    {
        if (iterator.Current != "disconnect")
            return new ParseResult.Failure("Not disconnect command.");

        iterator.MoveNext();
        var builder = new DisconnectCommandBuilder();

        if (iterator.Current is not null)
            return new ParseResult.CriticalFailure("Too many arguments for command.");

        return new ParseResult.Success(builder);
    }
}