namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

public abstract record BuildingResult
{
    private BuildingResult() { }

    public sealed record Success(ICommand Command) : BuildingResult;

    public sealed record Failure(string Message) : BuildingResult;
}