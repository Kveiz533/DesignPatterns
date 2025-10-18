namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

public interface IMessageFormatter
{
    string FormatTitle(string title);

    string FormatBody(string body);
}