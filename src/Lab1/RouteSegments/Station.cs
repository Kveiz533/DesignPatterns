using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.SegmentProcessor;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public record Station(Velocity VelocityLimit, Time BoardingTime, Time DisembarkingTime) : IRouteSegment
{
    public SegmentPassResult Process(ISegmentProcessor processor, ITrain train)
    {
        return processor.Process(this, train);
    }
}
