using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ConnectionParsers;

public sealed class DisconnectParser : BaseParser<DisconnectCommandBuilder>
{
    public DisconnectParser(
        ICommandParser? subChainCommands,
        IArgumentParser<DisconnectCommandBuilder>? subChainArguments)
        : base(subChainCommands, subChainArguments) { }

    protected override string CommandName => "disconnect";

    protected override DisconnectCommandBuilder CreateBuilder()
    {
        return new DisconnectCommandBuilder();
    }
}