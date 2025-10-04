using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class SimpleMagneticPath : IRouteSegment
{
    public Length Length { get; }

    public SimpleMagneticPath(Length length)
    {
        Length = length;
    }

    public SegmentResult GoThrough(SimpleTrain train)
    {
        TrainResult res = train.IntegrateMotion(Length);

        return res switch
        {
            TrainResult.Failure error => new SegmentResult.Failure(error.Message),
            TrainResult.Success success => new SegmentResult.Success(success.Time),
            _ => new SegmentResult.Failure("Unknown result"),
        };
    }
}
