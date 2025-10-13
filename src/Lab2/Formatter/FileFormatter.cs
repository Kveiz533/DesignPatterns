using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public sealed class FileFormatter : IFormatter
{
    private readonly FilePath _filePath;

    private readonly IMessageFormatter _messageFormatter;

    public FileFormatter(FilePath filePath, IMessageFormatter messageFormatter)
    {
        _filePath = filePath;
        _messageFormatter = messageFormatter;
    }

    public void Format(Message message)
    {
        string formattedTitle = _messageFormatter.FormatTitle(message.Title);
        string formattedBody = _messageFormatter.FormatBody(message.Body);

        File.AppendAllText(_filePath.Value, formattedTitle + Environment.NewLine);
        File.AppendAllText(_filePath.Value, formattedBody + Environment.NewLine + Environment.NewLine);
    }
}