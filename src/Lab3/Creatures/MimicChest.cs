using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class MimicChest : BaseCreature
{
    public MimicChest(Health health, Damage damage) : base(health, damage) { }

    public override ICreature Clone()
    {
        return new MimicChest(Health, Damage);
    }

    public override void Attack(ICreature target)
    {
        Damage = Damage.Max(Damage, target.Damage);
        Health = Health.Max(Health, target.Health);

        target.TakeDamage(Damage);
    }
}