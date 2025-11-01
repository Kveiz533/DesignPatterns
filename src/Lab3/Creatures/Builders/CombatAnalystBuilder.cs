using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class CombatAnalystBuilder : DefaultCreatureBuilder
{
    private readonly Damage _damageMultiplier;

    public CombatAnalystBuilder(Damage damageMultiplier)
    {
        _damageMultiplier = damageMultiplier;
    }

    protected override ICreature BuildCore()
    {
        Health initialHealth = Health ?? new Health(4);
        Damage initialDamage = Damage ?? new Damage(2);

        return new CombatAnalyst(initialHealth, initialDamage, _damageMultiplier);
    }
}