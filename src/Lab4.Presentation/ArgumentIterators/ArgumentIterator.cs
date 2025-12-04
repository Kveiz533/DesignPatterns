namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

public sealed class ArgumentIterator : IArgumentIterator
{
    private readonly IEnumerator<string> _enumerator;
    private string? _current;
    private bool _finished;

    public ArgumentIterator(IEnumerable<string> arg)
    {
        _enumerator = arg.GetEnumerator();
        MoveNext();
    }

    public string? Current()
    {
        return _finished ? null : _current;
    }

    public void MoveNext()
    {
        if (_enumerator.MoveNext())
        {
            _current = _enumerator.Current;
        }
        else
        {
            _finished = true;
            _current = null;
        }
    }
}