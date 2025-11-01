using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable : IPlayerTable
{
    private const int DefaultCreaturesLimit = 7;

    private readonly int _creaturesLimit;

    private readonly List<ICreature> _creatures = [];

    private List<ICreature> AliveCreatures => _creatures.Where(creature => creature.IsAlive).ToList();

    public PlayerTable(int? creaturesLimit = null)
    {
        _creaturesLimit = creaturesLimit ?? DefaultCreaturesLimit;
    }

    public AddCreatureResultType AddCreature(ICreature creature)
    {
        if (_creatures.Count >= _creaturesLimit)
        {
            return new AddCreatureResultType.LimitReached(_creaturesLimit);
        }

        _creatures.Add(creature);
        return new AddCreatureResultType.CreatureAdded();
    }

    public ICreature? FindAttackingCreature()
    {
        if (AliveCreatures.Count == 0)
        {
            return null;
        }

        int index = RandomNumberGenerator.GetInt32(AliveCreatures.Count);
        return AliveCreatures[index];
    }

    public ICreature? FindAttackedCreature()
    {
        if (AliveCreatures.Count == 0)
        {
            return null;
        }

        int index = RandomNumberGenerator.GetInt32(AliveCreatures.Count);
        return AliveCreatures[index];
    }

    public IPlayerTable Clone()
    {
        var clonedPlayerTable = new PlayerTable();

        foreach (ICreature creature in _creatures)
        {
            clonedPlayerTable.AddCreature(creature.Clone());
        }

        return clonedPlayerTable;
    }

    public SpellCastResult ApplyPotion(ISpell potion, ICreature targetCreature)
    {
        int index = _creatures.FindIndex(creature => creature == targetCreature);

        if (index == -1)
        {
            return SpellCastResult.NotCasted;
        }

        ICreature newCreature = potion.ApplyPotion(targetCreature);
        _creatures[index] = newCreature;
        return SpellCastResult.Casted;
    }
}