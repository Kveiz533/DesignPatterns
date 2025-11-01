using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class CombatAnalyst : BaseCreature
{
    private readonly Damage _damageIncrease;

    public CombatAnalyst(Health health, Damage damage, Damage damageMultiplier) : base(health, damage)
    {
        _damageIncrease = damageMultiplier;
    }

    public override ICreature Clone()
    {
        return new CombatAnalyst(Health, Damage, _damageIncrease);
    }

    public override void Attack(ICreature target)
    {
        Damage += _damageIncrease;
        target.TakeDamage(Damage);
    }
}