using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainRoute;

public class Route
{
    public IReadOnlyList<IRouteSegment> Segments { get; }

    public Velocity VelocityLimit { get; }

    public Route(IEnumerable<IRouteSegment> segments, Velocity velocityLimit)
    {
        VelocityLimit = velocityLimit;
        Segments = segments.ToList();
    }

    public SimulationResult RunSimulation(SimpleTrain train)
    {
        Time finalTime = Time.Zero;
        foreach (IRouteSegment segment in Segments)
        {
            SegmentResult result = segment.GoThrough(train);

            finalTime = result switch
            {
                SegmentResult.Success success => finalTime + success.Time,
                _ => finalTime,
            };

            if (result is SegmentResult.Failure error)
            {
                return new SimulationResult.SimulationEndedWithFailure(error.Message);
            }
        }

        return VelocityLimit > train.CurrentVelocity || VelocityLimit == train.CurrentVelocity
            ? new SimulationResult.SimulationEndedCorrectly(finalTime)
            : new SimulationResult.SimulationEndedWithFailure("Too much speed for the end of the route");
    }
}