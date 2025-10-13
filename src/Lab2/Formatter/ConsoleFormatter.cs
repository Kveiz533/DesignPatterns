using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public sealed class ConsoleFormatter : IFormatter
{
    private readonly IMessageFormatter _messageFormatter;

    public ConsoleFormatter(IMessageFormatter messageFormatter)
    {
        _messageFormatter = messageFormatter;
    }

    public void Format(Message message)
    {
        string formatedTitle = _messageFormatter.FormatTitle(message.Title);
        string formatedBody = _messageFormatter.FormatBody(message.Body);
        Console.WriteLine(formatedTitle);
        Console.WriteLine(formatedBody);
    }
}