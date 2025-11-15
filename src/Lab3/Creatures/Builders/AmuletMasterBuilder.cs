namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class AmuletMasterBuilder : DefaultCreatureBuilder
{
    protected override ICreature BuildCore()
    {
        return new AmuletMaster(
            Health ?? throw new ArgumentNullException(nameof(Health), "health is required"),
            Damage ?? throw new ArgumentNullException(nameof(Damage), "damage is required"));
    }
}