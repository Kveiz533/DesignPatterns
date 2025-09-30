namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Acceleration
{
    public decimal Value { get; }

    public static Acceleration Zero { get; } = new Acceleration(0m);

    public Acceleration(decimal acceleration)
    {
        Value = acceleration;
    }

    public static Acceleration Create(Force left, Mass right)
    {
        return new Acceleration(left.Value / right.Value);
    }
}