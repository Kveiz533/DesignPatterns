namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

public interface ICommandParser
{
    ParseResult Parse(IEnumerator<string> iterator);

    void AddNext(ICommandParser nextParser);
}