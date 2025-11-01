using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class ImmortalHorror : BaseCreature
{
    private readonly Health _healthAfterReincarnation;

    private bool _hasReincarnation = true;

    public ImmortalHorror(Health health, Damage damage, Health healthAfterReincarnation) : base(health, damage)
    {
        _healthAfterReincarnation = healthAfterReincarnation;
    }

    public override ICreature Clone()
    {
        return new ImmortalHorror(Health, Damage, _healthAfterReincarnation);
    }

    public override void TakeDamage(Damage damage)
    {
        Health = Health.DecreasedBy(damage);

        if (IsAlive || !_hasReincarnation)
        {
            return;
        }

        _hasReincarnation = false;
        Health = _healthAfterReincarnation;
    }
}