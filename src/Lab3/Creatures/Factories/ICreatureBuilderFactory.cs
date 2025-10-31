using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public interface ICreatureBuilderFactory
{
    ICreatureBuilder Create();
}