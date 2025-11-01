using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class MimicChestBuilder : DefaultCreatureBuilder
{
    protected override ICreature BuildCore()
    {
        Health initialHealth = Health ?? new Health(1);
        Damage initialDamage = Damage ?? new Damage(1);

        return new MimicChest(initialHealth, initialDamage);
    }
}