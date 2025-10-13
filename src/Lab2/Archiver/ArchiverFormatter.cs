using Itmo.ObjectOrientedProgramming.Lab2.Formatter;
using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver;

public sealed class ArchiverFormatter : IArchiver
{
    private readonly IFormatter _formatter;

    public ArchiverFormatter(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Archive(Message message)
    {
        _formatter.Format(message);
    }
}