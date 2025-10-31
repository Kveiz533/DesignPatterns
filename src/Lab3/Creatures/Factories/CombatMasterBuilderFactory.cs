using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class CombatMasterBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return new CombatAnalystBuilder();
    }
}