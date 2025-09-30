namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public record Time
{
    public decimal Value { get; }

    public static Time Zero { get; } = new Time(0m);

    public Time(decimal time)
    {
        if (time < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(time), time, "Time must be not negative");
        }

        Value = time;
    }

    public static Time operator +(Time left, Time right) => new Time(left.Value + right.Value);
}