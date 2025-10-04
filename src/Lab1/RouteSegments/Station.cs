using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class Station : IRouteSegment
{
    public Velocity VelocityLimit { get; }

    public Time BoardingTime { get; }

    public Time DisembarkingTime { get; }

    public Station(Velocity velocityLimit, Time boardingTime, Time disembarkingTime)
    {
        VelocityLimit = velocityLimit;
        BoardingTime = boardingTime;
        DisembarkingTime = disembarkingTime;
    }

    public SegmentResult GoThrough(SimpleTrain train)
    {
        if (VelocityLimit < train.CurrentVelocity)
        {
            return new SegmentResult.Failure("Too high velocity");
        }

        Time timePassed = BoardingTime + DisembarkingTime;
        return new SegmentResult.Success(timePassed);
    }
}
