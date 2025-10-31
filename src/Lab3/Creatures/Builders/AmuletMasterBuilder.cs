using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class AmuletMasterBuilder : DefaultCreatureBuilder
{
    public override ICreature Build()
    {
        Health initialHealth = Health ?? new Health(2);
        Damage initialDamage = Damage ?? new Damage(5);

        ICreature amuletMaster = new AmuletMaster(initialHealth, initialDamage);
        amuletMaster = new AttackMasteryModifier(new MagicShieldModifier(amuletMaster));
        return Factories.Aggregate(amuletMaster, (currentCreature, factory) => factory.Create(currentCreature));
    }
}