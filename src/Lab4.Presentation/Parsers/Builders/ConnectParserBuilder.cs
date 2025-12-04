using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ConnectionParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

public sealed class ConnectParserBuilder : BaseParserBuilder<ConnectCommandPrinterBuilder>
{
    public override ICommandParser Build()
    {
        return new ConnectParser(SubChainCommandsHead, SubChainArgumentsHead);
    }
}