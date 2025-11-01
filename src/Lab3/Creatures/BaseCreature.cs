using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class BaseCreature : ICreature
{
    protected BaseCreature(Health health, Damage damage)
    {
        Health = health;
        Damage = damage;
    }

    public bool IsAlive => Health > Health.Zero();

    public Health Health { get; protected set; }

    public Damage Damage { get; protected set; }

    public virtual void Attack(ICreature target)
    {
        target.TakeDamage(Damage);
    }

    public virtual void TakeDamage(Damage damage)
    {
        Health = Health.DecreasedBy(damage);
    }

    public virtual void SetAttack(Damage damage)
    {
        Damage = damage;
    }

    public virtual void SetHealth(Health health)
    {
        Health = health;
    }

    public abstract ICreature Clone();
}