using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Strategies;

public interface ISelectionStrategy
{
    ICreature? SelectAttackingCreature(IReadOnlyList<ICreature> creatures);

    ICreature? SelectAttackedCreature(IReadOnlyList<ICreature> creatures);
}