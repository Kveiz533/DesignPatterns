using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public sealed class AddresseeGroup : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public AddresseeGroup(IReadOnlyCollection<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}