using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class ImmortalHorrorBuilder : DefaultCreatureBuilder
{
    private readonly Health _healthAfterReincarnation;

    public ImmortalHorrorBuilder(Health healthAfterReincarnation)
    {
        _healthAfterReincarnation = healthAfterReincarnation;
    }

    protected override ICreature BuildCore()
    {
        return new ImmortalHorror(
            Health ?? throw new ArgumentNullException(nameof(Health), "health is required"),
            Damage ?? throw new ArgumentNullException(nameof(Damage), "damage is required"),
            _healthAfterReincarnation,
            true);
    }
}