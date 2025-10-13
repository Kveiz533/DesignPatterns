namespace Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

public record Title
{
    public Title(string title)
    {
        Value = title;
    }

    public string Value { get; }
}