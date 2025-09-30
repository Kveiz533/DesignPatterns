namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Force
{
    public decimal Value { get; }

    public static Force Zero { get; } = new Force(0m);

    public Force(decimal force)
    {
        Value = force;
    }

    public static bool operator >(Force left, Force right) => left.Value > right.Value;

    public static bool operator <(Force left, Force right) => left.Value < right.Value;
}