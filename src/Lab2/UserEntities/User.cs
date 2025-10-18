using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.UserEntities;

public class User
{
    private readonly Dictionary<Message, MessageStatus> _messages = [];

    public void ReceiveMessage(Message message)
    {
        if (_messages.ContainsKey(message))
        {
            throw new InvalidOperationException("Already received this message");
        }

        _messages.Add(message, new MessageStatus.NotRead());
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        return _messages.TryGetValue(message, out MessageStatus? status)
            ? status
            : new MessageStatus.NotExisted();
    }

    public MarkResult ReadMessage(Message message)
    {
        if (!_messages.TryGetValue(message, out MessageStatus? status))
            return new MarkResult.NotFound();

        if (status is not MessageStatus.NotRead)
            return new MarkResult.AlreadyMarked();

        _messages[message] = new MessageStatus.Read();
        return new MarkResult.Marked();
    }
}