using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record SegmentPassResult
{
    private SegmentPassResult() { }

    public sealed record Success(Time Time) : SegmentPassResult;

    public sealed record Failure(Time Time, string Message) : SegmentPassResult;
}