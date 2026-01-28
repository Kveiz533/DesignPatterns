namespace Itmo.ObjectOrientedProgramming.Lab2.SpecialWordsChecker;

public sealed class SimpleSpecialWordsChecker : ISpecialWordsChecker
{
    private readonly IReadOnlyCollection<string> _specialWords;

    public SimpleSpecialWordsChecker(IReadOnlyCollection<string> specialWords)
    {
        _specialWords = specialWords;
    }

    public bool IsContained(string text)
    {
        return _specialWords.Any(specialWord => text.Contains(specialWord, StringComparison.OrdinalIgnoreCase));
    }
}