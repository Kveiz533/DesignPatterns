namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public sealed class ConsoleFormatter : IFormatter
{
    public void FormatTitle(string title)
    {
        Console.WriteLine(title);
    }

    public void FormatBody(string body)
    {
        Console.WriteLine(body);
    }
}