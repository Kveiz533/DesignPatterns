using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;

namespace Itmo.ObjectOrientedProgramming.Lab3.FightEntities;

public class Fight
{
    private readonly IPlayerTable _playerTable1;

    private readonly IPlayerTable _playerTable2;

    public Fight(IPlayerTable playerTable1, IPlayerTable playerTable2)
    {
        _playerTable1 = playerTable1;
        _playerTable2 = playerTable2;
    }

    public FightResult Simulation()
    {
        FightResult result = FightResult.Continue;

        bool isPlayer1Attacking = true;

        IPlayerTable currentAttackingPlayer = _playerTable1;
        IPlayerTable currentDefendingPlayer = _playerTable2;

        while (result is FightResult.Continue)
        {
            ResultTypeReceiveCreature creature1 = currentAttackingPlayer.AttackingCreature();
            ResultTypeReceiveCreature creature2 = currentDefendingPlayer.AttackedCreature();

            if (creature1 is ResultTypeReceiveCreature.NotReceived &&
                creature2 is ResultTypeReceiveCreature.NotReceived)
            {
                result = FightResult.Draw;
            }
            else if (creature1 is ResultTypeReceiveCreature.NotReceived &&
                     creature2 is ResultTypeReceiveCreature.Received)
            {
                result = isPlayer1Attacking ? FightResult.Player2Win : FightResult.Player1Win;
            }
            else if (creature1 is ResultTypeReceiveCreature.Received &&
                     creature2 is ResultTypeReceiveCreature.NotReceived)
            {
                result = isPlayer1Attacking ? FightResult.Player1Win : FightResult.Player2Win;
            }
            else if (creature1 is ResultTypeReceiveCreature.Received received1 &&
                     creature2 is ResultTypeReceiveCreature.Received received2)
            {
                ICreature attackingCreature = received1.Creature;
                ICreature defendingCreature = received2.Creature;

                attackingCreature.Attack(defendingCreature);
            }

            (currentAttackingPlayer, currentDefendingPlayer) = (currentDefendingPlayer, currentAttackingPlayer);
            isPlayer1Attacking = !isPlayer1Attacking;
        }

        return result;
    }
}