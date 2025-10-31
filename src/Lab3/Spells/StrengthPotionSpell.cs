using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class StrengthPotionSpell : ISpell
{
    public ICreature ApplyPotion(ICreature target)
    {
        target.SetAttack(target.Damage + new Damage(5));
        return target;
    }
}