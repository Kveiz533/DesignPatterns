using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record SegmentResult
{
    private SegmentResult() { }

    public sealed record Success(Time Time) : SegmentResult;

    public sealed record Failure(string Message) : SegmentResult;
}