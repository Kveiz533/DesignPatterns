namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

public interface IArgumentIterator
{
    string? Current();

    void MoveNext();
}