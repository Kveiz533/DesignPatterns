using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.SegmentProcessor;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.Simulation;

public class RouteSimulator
{
    private readonly ISegmentProcessor _processor;

    public RouteSimulator(RouteSegmentProcessor processor)
    {
        _processor = processor;
    }

    public SimulationResult RunSimulation(Route route, ITrain train)
    {
        Time finalTime = Time.Zero;
        foreach (IRouteSegment segment in route.Segments)
        {
            SegmentPassResult result = segment.GoThrough(_processor, train);

            finalTime = result switch
            {
                SegmentPassResult.Failure failure => finalTime + failure.Time,
                SegmentPassResult.Success success => finalTime + success.Time,
                _ => finalTime,
            };

            if (result is SegmentPassResult.Failure error)
            {
                return new SimulationResult.SimulationEndedWithFailure(finalTime, error.Message);
            }
        }

        return route.VelocityLimit > train.CurrentVelocity || route.VelocityLimit == train.CurrentVelocity
            ? new SimulationResult.SimulationEndedCorrectly(finalTime)
            : new SimulationResult.SimulationEndedWithFailure(finalTime, "Too much speed for the end of the route");
    }
}