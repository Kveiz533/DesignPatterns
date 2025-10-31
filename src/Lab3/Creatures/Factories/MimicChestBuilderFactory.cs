using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class MimicChestBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return new MimicChestBuilder();
    }
}