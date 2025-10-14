using Itmo.ObjectOrientedProgramming.Lab2.Addressee;
using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.TopicEntities;

public class Topic
{
    private readonly IReadOnlyCollection<IAddressee> _addresses;

    public Topic(string name, IReadOnlyCollection<IAddressee> addresses)
    {
        Name = name;
        _addresses = addresses;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee address in _addresses)
        {
            address.ReceiveMessage(message);
        }
    }
}