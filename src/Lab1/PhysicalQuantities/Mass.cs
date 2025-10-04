namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Mass
{
    public double Value { get; }

    public Mass(double mass)
    {
        if (mass <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mass), mass, "Mass must be positive.");
        }

        Value = mass;
    }
}