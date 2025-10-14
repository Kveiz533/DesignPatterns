using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver;

public sealed class ArchiverInMemory : IArchiver
{
    private readonly List<Message> _messages = [];

    public void Archive(Message message)
    {
        _messages.Add(message);
    }
}