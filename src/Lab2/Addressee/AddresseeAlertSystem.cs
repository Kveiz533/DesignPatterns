using Itmo.ObjectOrientedProgramming.Lab2.AlertSystem;
using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab2.SpecialWordsChecker;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public sealed class AddresseeAlertSystem : IAddressee
{
    private readonly IAlertSystem _alertSystem;

    private readonly ISpecialWordsChecker _checker;

    public AddresseeAlertSystem(
        IAlertSystem alertSystem,
        ISpecialWordsChecker checker)
    {
        _alertSystem = alertSystem;
        _checker = checker;
    }

    public void ReceiveMessage(Message message)
    {
        if (_checker.IsContained(message.Title) || _checker.IsContained(message.Body))
        {
            _alertSystem.Notify();
        }
    }
}