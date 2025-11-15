using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class EvilFighterBuilderFactory : ICreatureBuilderFactory
{
    private const int DefaultDamageMultiplier = 2;

    private static readonly Damage DefaultDamage = new Damage(1);

    private static readonly Health DefaultHealth = new Health(6);

    private readonly int _damageMultiplier;

    public EvilFighterBuilderFactory(int? damageMultiplier = null)
    {
        _damageMultiplier = damageMultiplier ?? DefaultDamageMultiplier;
    }

    public ICreatureBuilder Create()
    {
        return new EvilFighterBuilder(_damageMultiplier)
            .ChangeDamage(DefaultDamage)
            .ChangeHealth(DefaultHealth);
    }
}