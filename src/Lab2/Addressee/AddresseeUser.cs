using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab2.UserEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public sealed class AddresseeUser : IAddressee
{
    private readonly User _user;

    public AddresseeUser(User user)
    {
        _user = user;
    }

    public void ReceiveMessage(Message message)
    {
        _user.ReceiveMessage(message);
    }
}