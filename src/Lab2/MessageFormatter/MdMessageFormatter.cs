using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

public sealed class MdMessageFormatter : IMessageFormatter
{
    public string FormatTitle(Title title)
    {
        return $"# {title.Value}";
    }

    public string FormatBody(Body body)
    {
        return $"{body.Value}";
    }
}