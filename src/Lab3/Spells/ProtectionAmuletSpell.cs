using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class ProtectionAmuletSpell : ISpell
{
    public ICreature ApplyPotion(ICreature target)
    {
        var magicShieldModifierFactory = new MagicShieldModifierFactory();
        return magicShieldModifierFactory.Create(target);
    }
}