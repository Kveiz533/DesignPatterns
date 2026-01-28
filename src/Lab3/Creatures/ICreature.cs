using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    bool IsAlive { get; }

    Health Health { get; }

    Damage Damage { get; }

    void Attack(ICreature target);

    void TakeDamage(Damage damage);

    void SetAttack(Damage damage);

    void SetHealth(Health health);

    ICreature Clone();
}
