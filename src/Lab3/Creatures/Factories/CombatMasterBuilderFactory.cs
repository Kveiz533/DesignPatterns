using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class CombatMasterBuilderFactory : ICreatureBuilderFactory
{
    private readonly Damage _defaultDamageIncrease = new Damage(2);

    private readonly Damage _damageIncrease;

    public CombatMasterBuilderFactory(Damage? damageMultiplier = null)
    {
        _damageIncrease = damageMultiplier ?? _defaultDamageIncrease;
    }

    public ICreatureBuilder Create()
    {
        return new CombatAnalystBuilder(_damageIncrease);
    }
}