using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class MimicChestBuilder : DefaultCreatureBuilder
{
    public override ICreature Build()
    {
        Health initialHealth = Health ?? new Health(1);
        Damage initialDamage = Damage ?? new Damage(1);

        ICreature mimicChest = new MimicChest(initialHealth, initialDamage);
        return Factories.Aggregate(mimicChest, (currentCreature, factory) => factory.Create(currentCreature));
    }
}