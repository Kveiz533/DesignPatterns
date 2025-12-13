using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.ConnectionParsers;

public sealed class DisconnectParser : BaseParser
{
    public override ParseResult Parse(IEnumerator<string> iterator)
    {
        if (iterator.Current != "disconnect")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        var builder = new DisconnectCommandBuilder();

        return iterator.Current is not null
            ? new ParseResult.Failure("Too many arguments for command.")
            : new ParseResult.Success(builder);
    }
}