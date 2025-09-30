namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Length
{
    public decimal Value { get; }

    public static Length Zero { get; } = new Length(0m);

    public Length(decimal lenght)
    {
        if (lenght < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lenght), lenght, "Lenght must be not negative.");
        }

        Value = lenght;
    }

    public static Length operator +(Length left, Length right) => new Length(left.Value + right.Value);

    public static Length Create(Velocity left, Time right)
    {
        return new Length(left.Value * right.Value);
    }

    public static bool operator >(Length left, Length right) => left.Value > right.Value;

    public static bool operator <(Length left, Length right) => left.Value < right.Value;
}
