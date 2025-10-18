namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

public sealed class MdMessageFormatter : IMessageFormatter
{
    public string FormatTitle(string title)
    {
        return $"# {title}";
    }

    public string FormatBody(string body)
    {
        return body;
    }
}