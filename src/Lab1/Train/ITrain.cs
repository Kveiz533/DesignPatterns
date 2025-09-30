using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Train;

public interface ITrain
{
    Time Precision { get; }

    Acceleration CurrentAcceleration { get; }

    Velocity CurrentVelocity { get; }

    Force MaxForce { get; }

    Mass Mass { get; }

    SegmentPassResult ApplyForce(Force force);

    SegmentPassResult CheckVelocityLimit(Velocity velocityLimit);

    void ChangeVelocity(Velocity velocity);
}