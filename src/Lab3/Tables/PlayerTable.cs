using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable : IPlayerTable
{
    private const int CreaturesLimit = 7;

    private readonly List<ICreature> _creatures = [];

    private List<ICreature> AttackedCreatures => _creatures.Where(creature => creature.IsAlive).ToList();

    private List<ICreature> AttackingCreatures => AttackedCreatures.Where(creature => creature.Damage > Damage.Zero()).ToList();

    public AddCreatureResultType AddCreature(ICreature creature)
    {
        if (_creatures.Count >= CreaturesLimit)
        {
            return new AddCreatureResultType.LimitReached(CreaturesLimit);
        }

        ICreature clonedCreature = creature.Clone();
        _creatures.Add(clonedCreature);
        return new AddCreatureResultType.CreatureAdded();
    }

    public ResultTypeReceiveCreature AttackingCreature()
    {
        if (AttackingCreatures.Count == 0)
        {
            return new ResultTypeReceiveCreature.NotReceived();
        }

        int index = RandomNumberGenerator.GetInt32(AttackingCreatures.Count);
        return new ResultTypeReceiveCreature.Received(AttackingCreatures[index]);
    }

    public ResultTypeReceiveCreature AttackedCreature()
    {
        if (AttackedCreatures.Count == 0)
        {
            return new ResultTypeReceiveCreature.NotReceived();
        }

        int index = RandomNumberGenerator.GetInt32(AttackedCreatures.Count);
        return new ResultTypeReceiveCreature.Received(AttackedCreatures[index]);
    }
}