using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class CombatAnalystBuilder : DefaultCreatureBuilder
{
    public override ICreature Build()
    {
        Health initialHealth = Health ?? new Health(4);
        Damage initialDamage = Damage ?? new Damage(2);

        ICreature combatAnalyst = new CombatAnalyst(initialHealth, initialDamage);
        return Factories.Aggregate(combatAnalyst, (currentCreature, factory) => factory.Create(currentCreature));
    }
}