using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

public abstract record SetArgumentResult
{
    private SetArgumentResult() { }

    public sealed record Success(ICommandBuilder Builder) : SetArgumentResult;

    public sealed record Failure(string Message) : SetArgumentResult;
}