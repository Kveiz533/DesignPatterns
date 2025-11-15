using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class MimicChestBuilderFactory : ICreatureBuilderFactory
{
    private static readonly Damage DefaultDamage = new Damage(1);

    private static readonly Health DefaultHealth = new Health(1);

    public ICreatureBuilder Create()
    {
        return new MimicChestBuilder()
            .ChangeHealth(DefaultHealth)
            .ChangeDamage(DefaultDamage);
    }
}