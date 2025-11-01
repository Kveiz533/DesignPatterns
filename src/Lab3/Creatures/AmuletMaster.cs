using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class AmuletMaster : BaseCreature
{
    public AmuletMaster(Health health, Damage damage) : base(health, damage) { }

    public override ICreature Clone()
    {
        return new AmuletMaster(Health, Damage);
    }
}