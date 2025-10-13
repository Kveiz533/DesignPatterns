namespace Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

public record Body
{
    public Body(string body)
    {
        Value = body;
    }

    public string Value { get; }
}