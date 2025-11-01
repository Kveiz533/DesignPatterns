using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;

namespace Itmo.ObjectOrientedProgramming.Lab3.FightEntities;

public class Fight
{
    private readonly IPlayerTable _playerTable1;

    private readonly IPlayerTable _playerTable2;

    public Fight(IPlayerTable playerTable1, IPlayerTable playerTable2)
    {
        _playerTable1 = playerTable1.Clone();
        _playerTable2 = playerTable2.Clone();
    }

    public FightResult Simulation()
    {
        bool isPlayer1Attacking = true;

        IPlayerTable currentAttackingPlayer = _playerTable1;
        IPlayerTable currentDefendingPlayer = _playerTable2;

        while (true)
        {
            ICreature? creature1 = currentAttackingPlayer.FindAttackingCreature();
            ICreature? creature2 = currentDefendingPlayer.FindAttackedCreature();

            if (creature1 is null && creature2 is null)
            {
                return FightResult.Draw;
            }

            if (creature1 is null && creature2 is not null)
            {
                return isPlayer1Attacking ? FightResult.Player2Win : FightResult.Player1Win;
            }

            if (creature1 is not null && creature2 is null)
            {
                return isPlayer1Attacking ? FightResult.Player1Win : FightResult.Player2Win;
            }

            if (creature1 is not null && creature2 is not null)
            {
                creature1.Attack(creature2);
            }

            (currentAttackingPlayer, currentDefendingPlayer) = (currentDefendingPlayer, currentAttackingPlayer);
            isPlayer1Attacking = !isPlayer1Attacking;
        }
    }
}