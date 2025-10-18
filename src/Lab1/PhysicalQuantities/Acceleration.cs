namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Acceleration
{
    public double Value { get; }

    public static Acceleration Zero { get; } = new Acceleration(0);

    public Acceleration(double acceleration)
    {
        Value = acceleration;
    }

    public static Acceleration Create(Force left, Mass right)
    {
        return new Acceleration(left.Value / right.Value);
    }
}