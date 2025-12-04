using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public interface ICommandParser
{
    ParseResult Parse(IArgumentIterator iterator);

    void AddNext(ICommandParser nextParser);
}