using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ConnectionParsers;

public sealed class ConnectParser : BaseParser<ConnectCommandPrinterBuilder>
{
    public ConnectParser(
        ICommandParser? subChainCommands,
        IArgumentParser<ConnectCommandPrinterBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "connect";

    protected override ConnectCommandPrinterBuilder CreateBuilder()
    {
        return new ConnectCommandPrinterBuilder();
    }
}