using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public abstract record ParseResult
{
    private ParseResult() { }

    public sealed record Success(ICommandBuilder Builder) : ParseResult;

    public sealed record Failure(string Message) : ParseResult;
}