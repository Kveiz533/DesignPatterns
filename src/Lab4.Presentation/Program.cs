using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    private static readonly List<string[]> TestCases = new()
    {
        new[] { "file" },
        new[] { "file", "copy" },
        new[] { "file", "copy", "a.txt" },
        new[] { "connect", "C:\\", "-m", "local" },
        new[] { "tree", "list", "-d", "2" },
        new[] { "connect", "C:\\Users", "-m", "local" },
        new[] { "connect", "/home", "-m", "cloud" },
        new[] { "disconnect" },
        new[] { "tree", "goto", "../test" },
        new[] { "tree", "list" },
        new[] { "tree", "list", "-d", "3" },
        new[] { "tree", "list", "-d", "two" },
        new[] { "tree", "list", "-z", "5" },
        new[] { "file", "show", "readme.txt", "-m", "console" },
        new[] { "file", "show", "-m", "console" },
        new[] { "file", "move", "source.txt", "dest/folder" },
        new[] { "file", "move", "source.txt" },
        new[] { "file", "copy", "A", "B" },
        new[] { "file", "copy", "source", "dest" },
        new[] { "file", "delete", "junk.tmp" },
        new[] { "file", "rename", "old_name", "new_name" },
        new[] { " " },
        new[] { "git", "push" },
        new[] { "file", "destroy", "a" },
        new[] { "file", "delete", "a", "b" },
    };

    public static void Main()
    {
        ICommandParser rootParser = ParserFactory.CreateRootParser();

        foreach (string[] args in TestCases)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Testing: {string.Join(" ", args)}");
            Console.ResetColor();

            var iterator = new ArgumentIterator(args);
            ParseResult result = rootParser.Parse(iterator);

            if (result is ParseResult.Success success)
            {
                BuildingResult a = success.Builder.Build();
                Console.WriteLine(success.ToString());
                Console.WriteLine(a.ToString());
                if (a is BuildingResult.Success command)
                {
                    Console.WriteLine(command.Command.ToString());
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(success.ToString());
            }
            else if (result is ParseResult.FailureWithParsing parseFail)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[Parsing Fail] {parseFail.Message}");
            }
            else if (result is ParseResult.FailureWithArguments argFail)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Args Fail] {argFail.Message}");
            }
            else
            {
                Console.WriteLine($"[Result] {result}");
            }

            Console.WriteLine(new string('-', 20));
        }
    }
}