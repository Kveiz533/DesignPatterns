using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal abstract class DefaultCreatureBuilder : ICreatureBuilder
{
    private readonly List<IModifierFactory> _factories = [];

    protected IReadOnlyCollection<IModifierFactory> Factories => _factories;

    protected Health? Health { get; private set; }

    protected Damage? Damage { get; private set; }

    public ICreatureBuilder AddModifier(IModifierFactory factory)
    {
        _factories.Add(factory);
        return this;
    }

    public ICreatureBuilder ChangeHealth(Health health)
    {
        Health = health;
        return this;
    }

    public ICreatureBuilder ChangeDamage(Damage damage)
    {
        Damage = damage;
        return this;
    }

    public abstract ICreature Build();
}