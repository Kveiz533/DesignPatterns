using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public interface IPlayerTable
{
    AddCreatureResultType AddCreature(ICreature creature);

    ResultTypeReceiveCreature AttackingCreature();

    ResultTypeReceiveCreature AttackedCreature();
}