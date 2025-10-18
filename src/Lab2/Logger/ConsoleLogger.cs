namespace Itmo.ObjectOrientedProgramming.Lab2.Logger;

public sealed class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}