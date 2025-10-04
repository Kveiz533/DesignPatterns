using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record TrainResult
{
    private TrainResult() { }

    public sealed record Success(Time Time) : TrainResult;

    public sealed record Failure(string Message) : TrainResult;
}