using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class AmuletMasterBuilderFactory : ICreatureBuilderFactory
{
    private static readonly Damage DefaultDamage = new Damage(5);

    private static readonly Health DefaultHealth = new Health(2);

    public ICreatureBuilder Create()
    {
        return new AmuletMasterBuilder()
            .ChangeHealth(DefaultHealth)
            .ChangeDamage(DefaultDamage)
            .AddModifier(new AttackMasteryModifierFactory())
            .AddModifier(new MagicShieldModifierFactory());
    }
}