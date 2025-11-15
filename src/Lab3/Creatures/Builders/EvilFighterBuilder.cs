namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

internal sealed class EvilFighterBuilder : DefaultCreatureBuilder
{
    private readonly int _damageMultiplier;

    public EvilFighterBuilder(int damageMultiplier)
    {
        _damageMultiplier = damageMultiplier;
    }

    protected override ICreature BuildCore()
    {
        return new EvilFighter(
            Health ?? throw new ArgumentNullException(nameof(Health), "health is required"),
            Damage ?? throw new ArgumentNullException(nameof(Damage), "damage is required"),
            _damageMultiplier);
    }
}