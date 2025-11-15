using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public interface ICreatureBuilder
{
    ICreatureBuilder AddModifier(IModifierFactory factory);

    ICreatureBuilder ChangeHealth(Health health);

    ICreatureBuilder ChangeDamage(Damage damage);

    ICreature Build();
}