using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public abstract record ResultTypeReceiveCreature
{
    private ResultTypeReceiveCreature() { }

    public sealed record Received(ICreature Creature) : ResultTypeReceiveCreature;

    public sealed record NotReceived : ResultTypeReceiveCreature;
}