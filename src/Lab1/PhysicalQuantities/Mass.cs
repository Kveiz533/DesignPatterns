namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Mass
{
    public decimal Value { get; }

    public Mass(decimal mass)
    {
        if (mass <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mass), mass, "Mass must be positive.");
        }

        Value = mass;
    }
}