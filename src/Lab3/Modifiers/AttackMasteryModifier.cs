using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class AttackMasteryModifier : ICreature
{
    private readonly ICreature _creature;

    public AttackMasteryModifier(ICreature creature)
    {
        _creature = creature;
    }

    public ICreature Clone()
    {
        return new AttackMasteryModifier(_creature.Clone());
    }

    public Health Health => _creature.Health;

    public Damage Damage => _creature.Damage;

    public bool IsAlive => _creature.IsAlive;

    public void Attack(ICreature target)
    {
        _creature.Attack(target);

        if (!target.IsAlive) return;

        _creature.Attack(target);
    }

    public void TakeDamage(Damage damage)
    {
        _creature.TakeDamage(damage);
    }

    public void SetAttack(Damage damage)
    {
        _creature.SetAttack(damage);
    }

    public void SetHealth(Health health)
    {
        _creature.SetHealth(health);
    }
}