using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Train;

public class SimpleTrain : ITrain
{
    public Time Precision { get; }

    public Acceleration CurrentAcceleration { get; private set; }

    public Velocity CurrentVelocity { get; private set; }

    public Force MaxForce { get; }

    public Mass Mass { get; }

    public SimpleTrain(Mass mass, Force force, Time precision)
    {
        Mass = mass;
        MaxForce = force;
        Precision = precision;
        CurrentVelocity = Velocity.Zero;
        CurrentAcceleration = Acceleration.Zero;
    }

    public SegmentPassResult ApplyForce(Force force)
    {
        if (force > MaxForce)
        {
            return new SegmentPassResult.Failure(Time.Zero, "Too much force was applied");
        }

        CurrentAcceleration = Acceleration.Create(force, Mass);
        return new SegmentPassResult.Success(Time.Zero);
    }

    public SegmentPassResult CheckVelocityLimit(Velocity velocityLimit)
    {
        return velocityLimit > CurrentVelocity || velocityLimit == CurrentVelocity
            ? new SegmentPassResult.Success(Time.Zero)
            : new SegmentPassResult.Failure(Time.Zero, "Too high velocity");
    }

    public void ChangeVelocity(Velocity velocity)
    {
        CurrentVelocity += velocity;
    }
}