using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class StaminaPotionSpell : ISpell
{
    public ICreature ApplyPotion(ICreature target)
    {
        target.SetHealth(target.Health + new Health(5));
        return target;
    }
}