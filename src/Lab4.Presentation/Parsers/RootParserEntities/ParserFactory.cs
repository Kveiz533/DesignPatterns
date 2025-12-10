using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.FlagArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers.PositionalArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ConnectionParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FileParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TreeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.TypeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.SubChainBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public static class ParserFactory
{
    public static RootParser CreateRootParser()
    {
        var connectParser = new ConnectParser(
            new ArgumentSubChainBuilder<ConnectCommandBuilder>()
                .AddFlag(new ModeFileSystemArgumentParser<ConnectCommandBuilder>(
                    new TypeSubChainBuilder<ConnectCommandBuilder>()
                        .AddType(new ModeFileSystemLocalTypeParser<ConnectCommandBuilder>())
                        .Build()))
                .AddPositionalArgument(new SourcePathArgumentParser<ConnectCommandBuilder>())
                .Build());

        var disconnectParser = new DisconnectParser();

        var treeGoToParser = new TreeGoToParser(
            new ArgumentSubChainBuilder<TreeGoToCommandBuilder>()
                .AddPositionalArgument(new SourcePathArgumentParser<TreeGoToCommandBuilder>())
                .Build());

        var treeList = new TreeListParser(
            new ArgumentSubChainBuilder<TreeListCommandBuilder>()
                .AddFlag(new DepthArgumentParser<TreeListCommandBuilder>())
                .Build());

        var fileShow = new FileShowParser(
            new ArgumentSubChainBuilder<FileShowCommandBuilder>()
                .AddPositionalArgument(new SourcePathArgumentParser<FileShowCommandBuilder>())
                .AddFlag(new ModeFormatterArgumentParser<FileShowCommandBuilder>(
                    new TypeSubChainBuilder<FileShowCommandBuilder>()
                        .AddType(new ModeFormatterConsoleTypeParser<FileShowCommandBuilder>())
                        .Build()))
                .Build());

        var fileMove = new FileMoveParser(
            new ArgumentSubChainBuilder<FileMoveCommandBuilder>()
                .AddPositionalArgument(new SourcePathArgumentParser<FileMoveCommandBuilder>())
                .AddPositionalArgument(new DestinationPathArgumentParser<FileMoveCommandBuilder>())
                .Build());

        var fileCopy = new FileCopyParser(
            new ArgumentSubChainBuilder<FileCopyCommandBuilder>()
                .AddPositionalArgument(new SourcePathArgumentParser<FileCopyCommandBuilder>())
                .AddPositionalArgument(new DestinationPathArgumentParser<FileCopyCommandBuilder>())
                .Build());

        var fileDelete = new FileDeleteParser(
            new ArgumentSubChainBuilder<FileDeleteCommandBuilder>()
                .AddPositionalArgument(new SourcePathArgumentParser<FileDeleteCommandBuilder>())
                .Build());

        var fileRename = new FileRenameParser(
            new ArgumentSubChainBuilder<FileRenameCommandBuilder>()
                .AddPositionalArgument(new SourcePathArgumentParser<FileRenameCommandBuilder>())
                .AddPositionalArgument(new NameArgumentParser<FileRenameCommandBuilder>())
                .Build());

        var file = new FileParser(
            new ParserSubChainBuilder()
                .AddParser(fileShow)
                .AddParser(fileMove)
                .AddParser(fileCopy)
                .AddParser(fileDelete)
                .AddParser(fileRename)
                .Build());

        var tree = new TreeParser(
            new ParserSubChainBuilder()
                .AddParser(treeGoToParser)
                .AddParser(treeList)
                .Build());

        var root = new RootParser(
            new ParserSubChainBuilder()
                .AddParser(connectParser)
                .AddParser(disconnectParser)
                .AddParser(file)
                .AddParser(tree)
                .Build());

        return root;
    }
}