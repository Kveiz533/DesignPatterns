using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.SegmentProcessor;

public class RouteSegmentProcessor : ISegmentProcessor
{
    public SegmentPassResult Process(SimpleMagneticPath segment, ITrain train)
    {
        return MotionIntegrator.IntegrateMotion(segment.Lenght, train);
    }

    public SegmentPassResult Process(PowerMagneticPath segment, ITrain train)
    {
        return train.ApplyForce(segment.Force) is SegmentPassResult.Failure error
            ? new SegmentPassResult.Failure(Time.Zero, error.Message)
            : MotionIntegrator.IntegrateMotion(segment.Lenght, train);
    }

    public SegmentPassResult Process(Station segment, ITrain train)
    {
        if (train.CheckVelocityLimit(segment.VelocityLimit) is SegmentPassResult.Failure error)
        {
            return new SegmentPassResult.Failure(Time.Zero, error.Message);
        }

        Time timePassed = segment.BoardingTime + segment.DisembarkingTime;
        return new SegmentPassResult.Success(timePassed);
    }
}