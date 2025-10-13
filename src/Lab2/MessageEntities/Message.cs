namespace Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

public class Message
{
    public Message(Title title, Body body, ImportanceLevel importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public Title Title { get; }

    public Body Body { get; }

    public ImportanceLevel ImportanceLevel { get; }
}