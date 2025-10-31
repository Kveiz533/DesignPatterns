namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

public record Health
{
    public Health(int health)
    {
        Value = health;
    }

    public int Value { get; }

    public static Health LoseHp(Health health, Damage damage)
    {
        return new Health(health.Value - damage.Value);
    }

    public static Health Zero()
    {
        return new Health(0);
    }

    public static bool operator >(Health a, Health b) => a.Value > b.Value;

    public static bool operator <(Health a, Health b) => a.Value < b.Value;

    public static Health operator +(Health a, Health b) => new Health(a.Value + b.Value);
}
