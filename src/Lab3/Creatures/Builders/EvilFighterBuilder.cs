using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class EvilFighterBuilder : DefaultCreatureBuilder
{
    public override ICreature Build()
    {
        Health initialHealth = Health ?? new Health(6);
        Damage initialDamage = Damage ?? new Damage(1);

        ICreature evilFighter = new EvilFighter(initialHealth, initialDamage);
        return Factories.Aggregate(evilFighter, (currentCreature, factory) => factory.Create(currentCreature));
    }
}