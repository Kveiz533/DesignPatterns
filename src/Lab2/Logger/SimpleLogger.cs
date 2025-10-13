using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Logger;

public sealed class SimpleLogger : ILogger
{
    public void Log(Message message)
    {
        Console.WriteLine($"Log: {message.Title.Value}, {message.Body.Value}");
    }
}