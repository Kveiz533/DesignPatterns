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
        return new CombatAnalyst(
            Health ?? throw new ArgumentNullException(nameof(Health), "health is required"),
            Damage ?? throw new ArgumentNullException(nameof(Damage), "damage is required"),
            _damageMultiplier);
    }
}