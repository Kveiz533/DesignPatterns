namespace Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

public abstract record MessageStatus
{
    private MessageStatus() { }

    public sealed record Read : MessageStatus;

    public sealed record NotRead : MessageStatus;

    public sealed record NotExisted : MessageStatus;
}