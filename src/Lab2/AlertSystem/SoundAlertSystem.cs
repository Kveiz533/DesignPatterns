namespace Itmo.ObjectOrientedProgramming.Lab2.AlertSystem;

public sealed class SoundAlertSystem : IAlertSystem
{
    public void Notify()
    {
        Console.Beep();
    }
}