using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class ParserFactory
{
    public static ICommandParser CreateRootParser()
    {
        ICommandParser connect = new ConnectParserBuilder()
            .AddPositional(new SourcePathArgumentParserBuilder<ConnectCommandPrinterBuilder>()
                .AddValueType(new SourcePathStringTypeParser<ConnectCommandPrinterBuilder>())
                .Build())
            .AddFlag(new ModeFileSystemArgumentParserBuilder<ConnectCommandPrinterBuilder>()
                .AddValueType(new ModeFileSystemLocalTypeParser<ConnectCommandPrinterBuilder>())
                .Build())
            .Build();

        ICommandParser disconnect = new DisconnectParserBuilder()
            .Build();

        ICommandParser treeGoTo = new TreeGoToParserBuilder()
            .AddPositional(new SourcePathArgumentParserBuilder<TreeGoToCommandBuilder>()
                .AddValueType(new SourcePathStringTypeParser<TreeGoToCommandBuilder>())
                .Build())
            .Build();

        ICommandParser treeList = new TreeListParserBuilder()
            .AddFlag(new DepthArgumentParserBuilder<TreeListCommandBuilder>()
                .AddValueType(new DepthPositiveIntTypeParser<TreeListCommandBuilder>())
                .Build())
            .Build();

        ICommandParser fileShow = new FileShowParserBuilder()
            .AddPositional(new SourcePathArgumentParserBuilder<FileShowCommandBuilder>()
                .AddValueType(new SourcePathStringTypeParser<FileShowCommandBuilder>())
                .Build())
            .AddFlag(new ModeFormatterArgumentParserBuilder<FileShowCommandBuilder>()
                .AddValueType(new ModeFormatterConsoleTypeParser<FileShowCommandBuilder>())
                .Build())
            .Build();

        ICommandParser fileMove = new FileMoveParserBuilder()
            .AddPositional(new SourcePathArgumentParserBuilder<FileMoveCommandBuilder>()
                .AddValueType(new SourcePathStringTypeParser<FileMoveCommandBuilder>())
                .Build())
            .AddPositional(new DestinationPathArgumentParserBuilder<FileMoveCommandBuilder>()
                .AddValueType(new DestinationPathStringTypeParser<FileMoveCommandBuilder>())
                .Build())
            .Build();

        ICommandParser fileCopy = new FileCopyParserBuilder()
            .AddPositional(new SourcePathArgumentParserBuilder<FileCopyCommandBuilder>()
                .AddValueType(new SourcePathStringTypeParser<FileCopyCommandBuilder>())
                .Build())
            .AddPositional(new DestinationPathArgumentParserBuilder<FileCopyCommandBuilder>()
                .AddValueType(new DestinationPathStringTypeParser<FileCopyCommandBuilder>())
                .Build())
            .Build();

        ICommandParser fileDelete = new FileDeleteParserBuilder()
            .AddPositional(new SourcePathArgumentParserBuilder<FileDeleteCommandBuilder>()
                .AddValueType(new SourcePathStringTypeParser<FileDeleteCommandBuilder>())
                .Build())
            .Build();

        ICommandParser fileRename = new FileRenameParserBuilder()
            .AddPositional(new SourcePathArgumentParserBuilder<FileRenameCommandBuilder>()
                .AddValueType(new SourcePathStringTypeParser<FileRenameCommandBuilder>())
                .Build())
            .AddPositional(new NameArgumentParserBuilder<FileRenameCommandBuilder>()
                .AddValueType(new NameStringTypeParser<FileRenameCommandBuilder>())
                .Build())
            .Build();

        ICommandParser tree = new TreeParserBuilder()
            .AddCommand(treeList)
            .AddCommand(treeGoTo)
            .Build();

        ICommandParser file = new FileParserBuilder()
            .AddCommand(fileShow)
            .AddCommand(fileMove)
            .AddCommand(fileCopy)
            .AddCommand(fileDelete)
            .AddCommand(fileRename)
            .Build();

        connect.AddNext(disconnect);
        tree.AddNext(connect);
        file.AddNext(tree);

        var rootParser = new RootParser(file);

        return rootParser;
    }
}