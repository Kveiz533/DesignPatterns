using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Simulation;

public class Route
{
    public IReadOnlyList<IRouteSegment> Segments { get; }

    public Velocity VelocityLimit { get; }

    public Route(IEnumerable<IRouteSegment> segments, Velocity velocityLimit)
    {
        VelocityLimit = velocityLimit;
        Segments = segments.ToList();
    }
}