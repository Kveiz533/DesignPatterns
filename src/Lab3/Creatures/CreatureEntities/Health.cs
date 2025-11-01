namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

public record Health
{
    public Health(int health)
    {
        Value = health;
    }

    public int Value { get; }

    public Health DecreasedBy(Damage damage)
    {
        return new Health(Value - damage.Value);
    }

    public static Health Zero()
    {
        return new Health(0);
    }

    public static Health Max(Health health1, Health health2)
    {
        return health1 > health2 ? new Health(health1.Value) : new Health(health2.Value);
    }

    public static bool operator >(Health a, Health b) => a.Value > b.Value;

    public static bool operator <(Health a, Health b) => a.Value < b.Value;

    public static Health operator +(Health a, Health b) => new Health(a.Value + b.Value);
}
