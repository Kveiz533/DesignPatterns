namespace Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

public class Message
{
    public Message(string title, string body, ImportanceLevel importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public string Title { get; }

    public string Body { get; }

    public ImportanceLevel ImportanceLevel { get; }
}