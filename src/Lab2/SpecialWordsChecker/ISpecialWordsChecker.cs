using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.SpecialWordsChecker;

public interface ISpecialWordsChecker
{
    bool IsContained(string specialWord, Message message);
}