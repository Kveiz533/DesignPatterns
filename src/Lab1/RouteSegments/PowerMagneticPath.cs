using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class PowerMagneticPath : IRouteSegment
{
    public Force Force { get; }

    public Length Length { get; }

    public PowerMagneticPath(Length length, Force force)
    {
        Force = force;
        Length = length;
    }

    public SegmentResult GoThrough(SimpleTrain train)
    {
        if (train.ApplyForce(Force) is TrainResult.Failure failure)
        {
            return new SegmentResult.Failure(failure.Message);
        }

        TrainResult res = train.Motion(Length);

        train.ApplyForce(Force.Zero);

        return res switch
        {
            TrainResult.Failure error => new SegmentResult.Failure(error.Message),
            TrainResult.Success success => new SegmentResult.Success(success.Time),
            _ => new SegmentResult.Failure("Unknown result"),
        };
    }
}