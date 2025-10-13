using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab2.UserEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public sealed class AddresseeGroup : IAddressee
{
    private readonly IReadOnlyCollection<User> _users;

    public AddresseeGroup(IReadOnlyCollection<User> users)
    {
        _users = users;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (User user in _users)
        {
            user.ReceiveMessage(message);
        }
    }
}