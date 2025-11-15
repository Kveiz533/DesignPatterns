using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public interface IPlayerTable
{
    AddCreatureResultType AddCreature(ICreature creature);

    ICreature? FindAttackingCreature();

    ICreature? FindAttackedCreature();

    IPlayerTable Clone();

    SpellCastResult ApplyPotion(ISpell potion, ICreature targetCreature);
}