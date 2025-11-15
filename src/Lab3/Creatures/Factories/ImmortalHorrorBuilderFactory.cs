using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class ImmortalHorrorBuilderFactory : ICreatureBuilderFactory
{
    private static readonly Damage DefaultDamage = new Damage(4);

    private static readonly Health DefaultHealth = new Health(4);

    private static readonly Health DefaultHealthAfterReincarnation = new Health(1);

    private readonly Health _healthAfterReincarnation;

    public ImmortalHorrorBuilderFactory(Health? healthAfterReincarnation = null)
    {
        _healthAfterReincarnation = healthAfterReincarnation ?? DefaultHealthAfterReincarnation;
    }

    public ICreatureBuilder Create()
    {
        return new ImmortalHorrorBuilder(_healthAfterReincarnation)
            .ChangeHealth(DefaultHealth)
            .ChangeDamage(DefaultDamage);
    }
}