namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Length
{
    public double Value { get; }

    public static Length Zero { get; } = new Length(0);

    public Length(double length)
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), length, "Lenght must be not negative.");
        }

        Value = length;
    }

    public static Length operator +(Length left, Length right) => new Length(left.Value + right.Value);

    public static Length Create(Velocity left, Time right)
    {
        return new Length(left.Value * right.Value);
    }

    public static bool operator >(Length left, Length right) => left.Value > right.Value;

    public static bool operator <(Length left, Length right) => left.Value < right.Value;
}
