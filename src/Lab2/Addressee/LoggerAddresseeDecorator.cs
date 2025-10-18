using Itmo.ObjectOrientedProgramming.Lab2.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public sealed class LoggerAddresseeDecorator : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly ILogger _logger;

    public LoggerAddresseeDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.Log(message.Title + message.Body);
        _addressee.ReceiveMessage(message);
    }
}