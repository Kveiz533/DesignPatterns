using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class EvilFighterBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return new EvilFighterBuilder();
    }
}