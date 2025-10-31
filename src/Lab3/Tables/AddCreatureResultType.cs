namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public abstract record AddCreatureResultType
{
    private AddCreatureResultType() { }

    public sealed record CreatureAdded : AddCreatureResultType;

    public sealed record LimitReached(int Limit) : AddCreatureResultType;
}