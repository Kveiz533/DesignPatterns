using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public sealed class FilterAddresseeProxy : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly ImportanceLevel _importanceLevelLimit;

    public FilterAddresseeProxy(IAddressee addressee, ImportanceLevel importanceLevelLimit)
    {
        _addressee = addressee;
        _importanceLevelLimit = importanceLevelLimit;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel >= _importanceLevelLimit)
        {
            _addressee.ReceiveMessage(message);
        }
    }
}