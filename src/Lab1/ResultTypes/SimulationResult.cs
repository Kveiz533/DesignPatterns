using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record SimulationResult
{
    private SimulationResult() { }

    public sealed record SimulationEndedCorrectly(Time Time) : SimulationResult;

    public sealed record SimulationEndedWithFailure(Time Time, string Message) : SimulationResult;
}