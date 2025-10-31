using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class EvilFighter : ICreature
{
    public EvilFighter(Health health, Damage damage)
    {
        Health = health;
        Damage = damage;
    }

    public ICreature Clone()
    {
        return new EvilFighter(Health, Damage);
    }

    public Health Health { get; private set; }

    public Damage Damage { get; private set; }

    public bool IsAlive => Health > Health.Zero();

    public void Attack(ICreature target)
    {
        target.TakeDamage(Damage);
    }

    public void TakeDamage(Damage damage)
    {
        Damage = Damage.Increase(Damage, 2);
        Health = Health.LoseHp(Health, damage);
    }

    public void SetAttack(Damage damage)
    {
        Damage = damage;
    }

    public void SetHealth(Health health)
    {
        Health = health;
    }
}