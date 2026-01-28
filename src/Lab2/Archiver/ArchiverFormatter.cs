using Itmo.ObjectOrientedProgramming.Lab2.Formatter;
using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver;

public sealed class ArchiverFormatter : IArchiver
{
    private readonly IFormatter _formatter;

    private readonly IMessageFormatter _messageFormatter;

    public ArchiverFormatter(IFormatter formatter, IMessageFormatter messageFormatter)
    {
        _formatter = formatter;
        _messageFormatter = messageFormatter;
    }

    public void Archive(Message message)
    {
        _formatter.FormatTitle(_messageFormatter.FormatTitle(message.Title));
        _formatter.FormatBody(_messageFormatter.FormatBody(message.Body));
    }
}