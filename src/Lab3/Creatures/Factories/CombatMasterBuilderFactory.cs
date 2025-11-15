using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class CombatMasterBuilderFactory : ICreatureBuilderFactory
{
    private static readonly Damage DefaultDamage = new Damage(2);

    private static readonly Health DefaultHealth = new Health(4);

    private static readonly Damage DefaultDamageIncrease = new Damage(2);

    private readonly Damage _damageIncrease;

    public CombatMasterBuilderFactory(Damage? damageMultiplier = null)
    {
        _damageIncrease = damageMultiplier ?? DefaultDamageIncrease;
    }

    public ICreatureBuilder Create()
    {
        return new CombatAnalystBuilder(_damageIncrease)
            .ChangeHealth(DefaultHealth)
            .ChangeDamage(DefaultDamage);
    }
}