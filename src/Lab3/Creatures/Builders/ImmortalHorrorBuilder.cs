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
        Health initialHealth = Health ?? new Health(4);
        Damage initialDamage = Damage ?? new Damage(4);

        return new ImmortalHorror(initialHealth, initialDamage, _healthAfterReincarnation);
    }
}