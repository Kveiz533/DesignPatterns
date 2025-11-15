using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Strategies;

public sealed class RandomStrategy : ISelectionStrategy
{
    public ICreature? SelectAttackingCreature(IReadOnlyList<ICreature> creatures)
    {
        int index = RandomNumberGenerator.GetInt32(creatures.Count);
        return creatures[index];
    }

    public ICreature? SelectAttackedCreature(IReadOnlyList<ICreature> creatures)
    {
        int index = RandomNumberGenerator.GetInt32(creatures.Count);
        return creatures[index];
    }
}