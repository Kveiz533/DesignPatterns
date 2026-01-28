using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class MagicShieldModifier : ICreature
{
    private readonly ICreature _creature;

    private bool _isActive = true;

    public MagicShieldModifier(ICreature creature)
    {
        _creature = creature;
    }

    public ICreature Clone()
    {
        var clone = new MagicShieldModifier(_creature.Clone()) { _isActive = _isActive };
        return clone;
    }

    public Health Health => _creature.Health;

    public Damage Damage => _creature.Damage;

    public bool IsAlive => _creature.IsAlive;

    public void Attack(ICreature target)
    {
        _creature.Attack(target);
    }

    public void TakeDamage(Damage damage)
    {
        if (_isActive)
        {
            _isActive = false;
        }
        else
        {
            _creature.TakeDamage(damage);
        }
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