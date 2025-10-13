using Itmo.ObjectOrientedProgramming.Lab2.Archiver;
using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public sealed class AddresseeArchiver : IAddressee
{
    private readonly IArchiver _archiver;

    public AddresseeArchiver(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public void ReceiveMessage(Message message)
    {
        _archiver.Archive(message);
    }
}