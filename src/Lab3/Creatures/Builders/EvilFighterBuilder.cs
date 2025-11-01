using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class EvilFighterBuilder : DefaultCreatureBuilder
{
    private readonly int _damageMultiplier;

    public EvilFighterBuilder(int damageMultiplier)
    {
        _damageMultiplier = damageMultiplier;
    }

    protected override ICreature BuildCore()
    {
        Health initialHealth = Health ?? new Health(6);
        Damage initialDamage = Damage ?? new Damage(1);

        return new EvilFighter(initialHealth, initialDamage, _damageMultiplier);
    }
}