using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class ImmortalHorror : ICreature
{
    public ImmortalHorror(Health health, Damage damage)
    {
        Health = health;
        Damage = damage;
    }

    public ICreature Clone()
    {
        return new ImmortalHorror(Health, Damage);
    }

    public Health Health { get; private set; }

    public Damage Damage { get; private set; }

    public bool IsAlive => Health > Health.Zero();

    private bool _hasReincarnation = true;

    public void Attack(ICreature target)
    {
        target.TakeDamage(Damage);
    }

    public void TakeDamage(Damage damage)
    {
        if (damage.Value >= Health.Value && _hasReincarnation)
        {
            _hasReincarnation = false;
            Health = new Health(1);
        }
        else
        {
            Health = Health.LoseHp(Health, damage);
        }
    }

    public void SetAttack(Damage damage)
    {
        Damage = damage;
    }

    public void SetHealth(Health health)
    {
        Health = health;
    }
}