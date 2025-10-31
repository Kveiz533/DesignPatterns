using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class MagicMirrorSpell : ISpell
{
    public ICreature ApplyPotion(ICreature target)
    {
        Health health = target.Health;
        Damage damage = target.Damage;
        target.SetAttack(new Damage(health.Value));
        target.SetHealth(new Health(damage.Value));

        return target;
    }
}