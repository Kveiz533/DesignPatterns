using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.SpecialWordsChecker;

public sealed class SimpleSpecialWordsChecker : ISpecialWordsChecker
{
    public bool IsContained(string specialWord, Message message)
    {
        return message.Title.Value.Contains(specialWord, StringComparison.InvariantCultureIgnoreCase) ||
               message.Body.Value.Contains(specialWord, StringComparison.InvariantCultureIgnoreCase);
    }
}