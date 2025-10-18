using Itmo.ObjectOrientedProgramming.Lab2.AlertSystem;
using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab2.SpecialWordsChecker;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public sealed class AddresseeAlertSystem : IAddressee
{
    private readonly IAlertSystem _alertSystem;

    private readonly ISpecialWordsChecker _checker;

    private readonly IReadOnlyCollection<string> _specialWords;

    public AddresseeAlertSystem(
        IAlertSystem alertSystem,
        IReadOnlyCollection<string> specialWords,
        ISpecialWordsChecker checker)
    {
        _alertSystem = alertSystem;
        _specialWords = specialWords;
        _checker = checker;
    }

    public void ReceiveMessage(Message message)
    {
        bool hasSpecialWords = _specialWords.Any(specialWord =>
            _checker.IsContained(specialWord, message.Title) ||
            _checker.IsContained(specialWord, message.Body));

        if (hasSpecialWords)
        {
            _alertSystem.Notify();
        }
    }
}