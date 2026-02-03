using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.FlagArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.PositionalArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.ConnectionParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.FileParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.TreeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.RootParserEntities;

public static class ParserFactory
{
    public static RootParser CreateRootParser()
    {
        var connectParser = new ConnectParser(
            new SourcePathArgumentParser<ConnectCommandBuilder>()
                .AddNext(new ModeFileSystemArgumentParser<ConnectCommandBuilder>(
                    new ModeFileSystemLocalTypeParser<ConnectCommandBuilder>())));

        var disconnectParser = new DisconnectParser();

        var treeGoToParser = new TreeGoToParser(
                new SourcePathArgumentParser<TreeGoToCommandBuilder>());

        var treeList =
            new TreeListParser(
                new DepthArgumentParser<TreeListCommandBuilder>(
                    new DepthTypeParser<TreeListCommandBuilder>()));

        var fileShow = new FileShowParser(
            new SourcePathArgumentParser<FileShowCommandBuilder>()
                .AddNext(new ModeFormatterArgumentParser<FileShowCommandBuilder>(
                    new ModeFormatterConsoleTypeParser<FileShowCommandBuilder>())));

        var fileMove = new FileMoveParser(
                new SourcePathArgumentParser<FileMoveCommandBuilder>()
                    .AddNext(new DestinationPathArgumentParser<FileMoveCommandBuilder>()));

        var fileCopy = new FileCopyParser(
                new SourcePathArgumentParser<FileCopyCommandBuilder>()
                    .AddNext(new DestinationPathArgumentParser<FileCopyCommandBuilder>()));

        var fileDelete = new FileDeleteParser(
            new SourcePathArgumentParser<FileDeleteCommandBuilder>());

        var fileRename = new FileRenameParser(
                new SourcePathArgumentParser<FileRenameCommandBuilder>()
                    .AddNext(new NameArgumentParser<FileRenameCommandBuilder>()));

        var file = new FileParser(
                fileShow
                .AddNext(fileMove)
                .AddNext(fileCopy)
                .AddNext(fileDelete)
                .AddNext(fileRename));

        var tree = new TreeParser(
                treeGoToParser
                .AddNext(treeList));

        var root = new RootParser(
                connectParser
                .AddNext(disconnectParser)
                .AddNext(file)
                .AddNext(tree));

        return root;
    }
}