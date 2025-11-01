using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class ImmortalHorrorBuilderFactory : ICreatureBuilderFactory
{
    private readonly Health _defaultHealthAfterReincarnation = new Health(1);

    private readonly Health _healthAfterReincarnation;

    public ImmortalHorrorBuilderFactory(Health? healthAfterReincarnation = null)
    {
        _healthAfterReincarnation = healthAfterReincarnation ?? _defaultHealthAfterReincarnation;
    }

    public ICreatureBuilder Create()
    {
        return new ImmortalHorrorBuilder(_healthAfterReincarnation);
    }
}