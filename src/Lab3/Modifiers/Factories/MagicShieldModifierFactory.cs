using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public sealed class MagicShieldModifierFactory : IModifierFactory
{
    public ICreature Create(ICreature creature)
    {
        return new MagicShieldModifier(creature);
    }
}