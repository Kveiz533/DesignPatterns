namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

public record Damage
{
    public Damage(int damage)
    {
        Value = damage;
    }

    public int Value { get; }

    public static Damage Zero()
    {
        return new Damage(0);
    }

    public static Damage Increase(Damage damage, int times)
    {
        return new Damage(damage.Value * times);
    }

    public static Damage operator +(Damage a, Damage b) => new Damage(a.Value + b.Value);

    public static bool operator <(Damage a, Damage b) => a.Value < b.Value;

    public static bool operator >(Damage a, Damage b) => a.Value > b.Value;
}