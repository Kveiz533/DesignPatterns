using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class ImmortalHorrorBuilder : DefaultCreatureBuilder
{
    public override ICreature Build()
    {
        Health initialHealth = Health ?? new Health(4);
        Damage initialDamage = Damage ?? new Damage(4);

        ICreature immortalHorror = new ImmortalHorror(initialHealth, initialDamage);
        return Factories.Aggregate(immortalHorror, (currentCreature, factory) => factory.Create(currentCreature));
    }
}