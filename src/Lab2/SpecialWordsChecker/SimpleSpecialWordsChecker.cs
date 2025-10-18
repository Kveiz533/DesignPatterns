namespace Itmo.ObjectOrientedProgramming.Lab2.SpecialWordsChecker;

public sealed class SimpleSpecialWordsChecker : ISpecialWordsChecker
{
    public bool IsContained(string specialWord, string word)
    {
        return word.Contains(specialWord, StringComparison.InvariantCultureIgnoreCase);
    }
}