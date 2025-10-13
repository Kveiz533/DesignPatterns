namespace Itmo.ObjectOrientedProgramming.Lab2.AlertSystem;

public sealed class TextAlertSystem : IAlertSystem
{
    private readonly string _message;

    public TextAlertSystem(string message)
    {
        _message = message;
    }

    public void Notify()
    {
        Console.WriteLine(_message);
    }
}