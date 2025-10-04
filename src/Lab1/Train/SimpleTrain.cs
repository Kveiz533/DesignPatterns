using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Train;

public class SimpleTrain
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

    public TrainResult ApplyForce(Force force)
    {
        if (force > MaxForce)
        {
            return new TrainResult.Failure("Too much force was applied");
        }

        CurrentAcceleration = Acceleration.Create(force, Mass);
        return new TrainResult.Success(Time.Zero);
    }

    public TrainResult CheckVelocityLimit(Velocity velocityLimit)
    {
        return velocityLimit > CurrentVelocity || velocityLimit == CurrentVelocity
            ? new TrainResult.Success(Time.Zero)
            : new TrainResult.Failure("Too high velocity");
    }

    public void ChangeVelocity(Velocity velocity)
    {
        CurrentVelocity += velocity;
    }

    public TrainResult IntegrateMotion(Length segmentLength)
    {
        Length distancePassed = Length.Zero;
        Time timePassed = Time.Zero;

        while (distancePassed < segmentLength)
        {
            ChangeVelocity(Velocity.Create(CurrentAcceleration, Precision));

            if (CurrentVelocity < Velocity.Zero || CurrentVelocity == Velocity.Zero)
            {
                return new TrainResult.Failure("The velocity is 0, the train has stopped");
            }

            distancePassed += Length.Create(CurrentVelocity, Precision);
            timePassed += Precision;
        }

        return new TrainResult.Success(timePassed);
    }
}