namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Velocity
{
    public decimal Value { get; }

    public static Velocity Zero { get; } = new Velocity(0m);

    public Velocity(decimal velocity)
    {
        Value = velocity;
    }

    public static Velocity Create(Acceleration left, Time right)
    {
        return new Velocity(left.Value * right.Value);
    }

    public static bool operator >(Velocity left, Velocity right) => left.Value > right.Value;

    public static bool operator <(Velocity left, Velocity right) => left.Value < right.Value;

    public static Velocity operator +(Velocity left, Velocity right) => new Velocity(left.Value + right.Value);
}