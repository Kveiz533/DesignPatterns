using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class EvilFighter : BaseCreature
{
    private readonly int _damageMultiplier;

    public EvilFighter(Health health, Damage damage, int damageMultiplier) : base(health, damage)
    {
        _damageMultiplier = damageMultiplier;
    }

    public override ICreature Clone()
    {
        return new EvilFighter(Health, Damage,  _damageMultiplier);
    }

    public override void TakeDamage(Damage damage)
    {
        Damage *= _damageMultiplier;
        Health = Health.DecreasedBy(damage);
    }
}