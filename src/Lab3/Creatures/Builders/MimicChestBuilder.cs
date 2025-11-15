namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class MimicChestBuilder : DefaultCreatureBuilder
{
    protected override ICreature BuildCore()
    {
        return new MimicChest(
            Health ?? throw new ArgumentNullException(nameof(Health), "health is required"),
            Damage ?? throw new ArgumentNullException(nameof(Damage), "damage is required"));
    }
}