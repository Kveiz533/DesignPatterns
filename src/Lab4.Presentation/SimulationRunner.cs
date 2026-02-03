using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.RootParserEntities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class SimulationRunner
{
    public void Run()
    {
        RootParser parser = ParserFactory.CreateRootParser();
        var session = new Session();

        while (true)
        {
            string? command = Console.ReadLine();

            if (command is null)
            {
                Console.WriteLine("Null command.");
            }
            else if (command == "exit")
            {
                break;
            }
            else
            {
                IEnumerator<string> iterator = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().GetEnumerator();
                ParseResult parseResult = parser.Parse(iterator);

                if (parseResult is ParseResult.Failure failure)
                {
                    Console.WriteLine(failure.Message);
                }
                else if (parseResult is ParseResult.Success success)
                {
                    BuildingResult buildingResult = success.Builder.Build();

                    if (buildingResult is BuildingResult.Failure buildingFailure)
                    {
                        Console.WriteLine(buildingFailure.Message);
                    }
                    else if (buildingResult is BuildingResult.Success buildingSuccess)
                    {
                        CommandResult commandResult = buildingSuccess.Command.Execute(session);

                        if (commandResult is CommandResult.Failure commandFailure)
                        {
                            Console.WriteLine(commandFailure.Message);
                        }
                        else
                        {
                            Console.WriteLine("Success!");
                        }
                    }
                }
            }
        }
    }
}