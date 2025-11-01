using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class EvilFighterBuilderFactory : ICreatureBuilderFactory
{
    private const int DefaultDamageMultiplier = 2;

    private readonly int _damageMultiplier;

    public EvilFighterBuilderFactory(int? damageMultiplier = null)
    {
        _damageMultiplier = damageMultiplier ?? DefaultDamageMultiplier;
    }

    public ICreatureBuilder Create()
    {
        return new EvilFighterBuilder(_damageMultiplier);
    }
}