using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.RootParserEntities;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    private const string Path = "C:\\Test";

    private static readonly List<string[]> CorrectCommands =
    [
        ["connect", "A", "-m", "local"],
        ["connect", "A"],
        ["disconnect"],
        ["tree", "goto", "A"],
        ["tree", "list", "-d", "10"],
        ["file", "show", "A", "-m", "console"],
        ["file", "move", "A", "B"],
        ["file", "copy", "A", "B"],
        ["file", "delete", "A"],
        ["file", "rename", "A", "B"]
    ];

    private static readonly List<string[]> CommandsWithExtraArguments =
    [
        ["connect", "A", "EXTRA"],
        ["disconnect", "EXTRA"],

        ["tree", "goto", "A", "EXTRA"],
        ["tree", "list", "-d", "10", "EXTRA"],

        ["file", "show", "A", "-m", "console", "EXTRA"],
        ["file", "move", "A", "B", "EXTRA"],
        ["file", "copy", "A", "B", "EXTRA"],
        ["file", "delete", "A", "EXTRA"],
        ["file", "rename", "A", "B", "EXTRA"]
    ];

    private static readonly List<string[]> CommandsWithLessArguments =
    [
        ["connect"],
        ["tree", "goto"],
        ["tree", "list", "-d"],
        ["file", "show", "A", "-m"],
        ["file", "move", "A"],
        ["file", "copy", "A"],
        ["file", "delete"],
        ["file", "rename", "A"]
    ];

    private static readonly List<string[]> CommandsWrongTypesOrFlagsArguments =
    [
        ["connect",  "A", "-m"],
        ["connect", "-m", "a", "A"],

        ["tree", "list"],
        ["tree", "list", "-d"],
        ["tree", "list", "-d", "-1"],
        ["tree", "list", "-d", "one"],
        ["tree", "list", "-d", "1", "-d", "1"],

        ["file", "show", "A"],
        ["file", "show", "A", "-m"],
        ["file", "show", "A", "-m", "A"],
        ["file", "show", "A", "-m", "A", "-d", "10"],
    ];

    [Fact]
    public void ParserTests_CorrectCommands_EverythingParsed()
    {
        // Arrange
        RootParser rootParser = ParserFactory.CreateRootParser();

        // Act
        foreach (string[] command in CorrectCommands)
        {
            ParseResult result = rootParser.Parse(command.ToList().GetEnumerator());

            // Assert
            Assert.IsType<ParseResult.Success>(result);

            if (result is ParseResult.Success success)
            {
                Assert.IsType<BuildingResult.Success>(success.Builder.Build());
            }
        }
    }

    [Fact]
    public void ParserTests_CommandsWithExtraArguments_EverythingFailed()
    {
        // Arrange
        RootParser rootParser = ParserFactory.CreateRootParser();

        // Act
        foreach (string[] command in CommandsWithExtraArguments)
        {
            ParseResult result = rootParser.Parse(command.ToList().GetEnumerator());

            // Assert
            Assert.IsNotType<ParseResult.Success>(result);
        }
    }

    [Fact]
    public void ParserTests_CommandsWithLessArguments_EverythingFailed()
    {
        // Arrange
        RootParser rootParser = ParserFactory.CreateRootParser();

        // Act
        foreach (string[] command in CommandsWithLessArguments)
        {
            ParseResult result = rootParser.Parse(command.ToList().GetEnumerator());

            // Assert
            if (result is ParseResult.Success success)
            {
                Assert.IsNotType<BuildingResult.Success>(success.Builder.Build());
            }
            else
            {
                Assert.IsNotType<ParseResult.Success>(result);
            }
        }
    }

    [Fact]
    public void ParserTests_CommandsWrongTypesOrFlagsArguments_EverythingFailed()
    {
        // Arrange
        RootParser rootParser = ParserFactory.CreateRootParser();

        // Act
        foreach (string[] command in CommandsWrongTypesOrFlagsArguments)
        {
            ParseResult result = rootParser.Parse(command.ToList().GetEnumerator());

            // Assert
            if (result is ParseResult.Success success)
            {
                Assert.IsNotType<BuildingResult.Success>(success.Builder.Build());
            }
            else
            {
                Assert.IsNotType<ParseResult.Success>(result);
            }
        }
    }

    [Fact]
    public void ParseTests_ConnectTwoTimes_ConnectOnlyOneTime()
    {
        // Arrange
        IFileSystem mockFileSystem = Substitute.For<IFileSystem>();
        mockFileSystem.DirectoryExists(Arg.Any<string>()).Returns(true);
        var session = new Session();

        // Act
        bool firstAttempt = session.Connect(mockFileSystem, Path);
        bool secondAttempt = session.Connect(mockFileSystem, Path);

        // Assert
        Assert.True(firstAttempt);
        Assert.False(secondAttempt);
    }

    [Fact]
    public void ParseTests_DisconnectTwoTimes_DisconnectOnlyOneTime()
    {
        // Arrange
        IFileSystem mockFileSystem = Substitute.For<IFileSystem>();
        mockFileSystem.DirectoryExists(Arg.Any<string>()).Returns(true);
        var session = new Session();

        // Act
        bool firstAttempt = session.Connect(mockFileSystem, Path);
        bool secondAttempt = session.Disconnect();
        bool thirdAttempt = session.Disconnect();

        // Assert
        Assert.True(firstAttempt);
        Assert.True(secondAttempt);
        Assert.False(thirdAttempt);
    }
}