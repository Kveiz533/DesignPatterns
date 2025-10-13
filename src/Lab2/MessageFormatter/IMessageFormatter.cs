using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

public interface IMessageFormatter
{
    string FormatTitle(Title title);

    string FormatBody(Body body);
}