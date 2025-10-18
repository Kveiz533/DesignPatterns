using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public interface IAddressee
{
    void ReceiveMessage(Message message);
}