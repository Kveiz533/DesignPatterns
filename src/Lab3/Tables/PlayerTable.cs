using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Strategies;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable : IPlayerTable
{
    private const int DefaultCreaturesLimit = 7;

    private readonly int _creaturesLimit;

    private readonly ISelectionStrategy _strategy;

    private readonly List<ICreature> _creatures = [];

    private List<ICreature> AliveCreatures => _creatures.Where(creature => creature.IsAlive).ToList();

    public PlayerTable(ISelectionStrategy strategy, int? creaturesLimit = null)
    {
        _creaturesLimit = creaturesLimit ?? DefaultCreaturesLimit;
        _strategy = strategy;
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
        return AliveCreatures.Count == 0 ? null : _strategy.SelectAttackingCreature(AliveCreatures);
    }

    public ICreature? FindAttackedCreature()
    {
        return AliveCreatures.Count == 0 ? null : _strategy.SelectAttackedCreature(AliveCreatures);
    }

    public IPlayerTable Clone()
    {
        var clonedPlayerTable = new PlayerTable(_strategy, _creaturesLimit);

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