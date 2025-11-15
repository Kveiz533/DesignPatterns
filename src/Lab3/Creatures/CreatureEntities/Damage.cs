namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

public record Damage
{
    public Damage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage), "Damage cannot be less than 0");
        }

        Value = damage;
    }

    public int Value { get; }

    public static Damage Zero()
    {
        return new Damage(0);
    }

    public static Damage Max(Damage damage1, Damage damage2)
    {
        return damage1 > damage2 ? new Damage(damage1.Value) : new Damage(damage2.Value);
    }

    public static Damage operator +(Damage a, Damage b) => new Damage(a.Value + b.Value);

    public static Damage operator *(Damage a, int b) => new Damage(a.Value * b);

    public static bool operator <(Damage a, Damage b) => a.Value < b.Value;

    public static bool operator >(Damage a, Damage b) => a.Value > b.Value;
}