using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.SegmentProcessor;

public static class MotionIntegrator
{
    public static SegmentPassResult IntegrateMotion(Length segmentLength, ITrain train)
    {
        Length distancePassed = Length.Zero;
        Time timePassed = Time.Zero;

        while (distancePassed < segmentLength)
        {
            train.ChangeVelocity(Velocity.Create(train.CurrentAcceleration, train.Precision));

            if (train.CurrentVelocity < Velocity.Zero || train.CurrentVelocity == Velocity.Zero)
            {
                return new SegmentPassResult.Failure(timePassed, "The velocity is 0, the train has stopped");
            }

            distancePassed += Length.Create(train.CurrentVelocity, train.Precision);
            timePassed += train.Precision;
        }

        train.ApplyForce(Force.Zero);

        return new SegmentPassResult.Success(timePassed);
    }
}