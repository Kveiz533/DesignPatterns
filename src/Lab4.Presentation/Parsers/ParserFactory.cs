using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectionCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class ParserFactory
{
    public static ICommandParser CreateRootParser()
    {
        var connectBuilder = new ConnectParserBuilder();
        var disconnectBuilder = new DisconnectParserBuilder();
        var fileBuilder = new FileParserBuilder();
        var treeBuilder = new TreeParserBuilder();

        var fileShowBuilder = new FileShowParserBuilder();
        var fileMoveBuilder = new FileMoveParserBuilder();
        var fileCopyBuilder = new FileCopyParserBuilder();
        var fileDeleteBuilder = new FileDeleteParserBuilder();
        var fileRenameBuilder = new FileRenameParserBuilder();

        var treeGoToBuilder = new TreeGoToParserBuilder();
        var treeListBuilder = new TreeListParserBuilder();

        connectBuilder.AddPositional(new SourcePathArgumentParser<ConnectCommandPrinterBuilder>());
        connectBuilder.AddFlag(new ModeFileSystemArgumentParser<ConnectCommandPrinterBuilder>());

        treeGoToBuilder.AddPositional(new SourcePathArgumentParser<TreeGoToCommandBuilder>());
        treeListBuilder.AddFlag(new DepthArgumentParser<TreeListCommandBuilder>());

        fileShowBuilder.AddPositional(new SourcePathArgumentParser<FileShowCommandBuilder>());
        fileShowBuilder.AddFlag(new ModeFormatterArgumentParser<FileShowCommandBuilder>());

        fileMoveBuilder.AddPositional(new SourcePathArgumentParser<FileMoveCommandBuilder>());
        fileMoveBuilder.AddPositional(new DestinationPathArgumentParser<FileMoveCommandBuilder>());

        fileCopyBuilder.AddPositional(new SourcePathArgumentParser<FileCopyCommandBuilder>());
        fileCopyBuilder.AddPositional(new DestinationPathArgumentParser<FileCopyCommandBuilder>());

        fileDeleteBuilder.AddPositional(new SourcePathArgumentParser<FileDeleteCommandBuilder>());

        fileRenameBuilder.AddPositional(new SourcePathArgumentParser<FileRenameCommandBuilder>());
        fileRenameBuilder.AddPositional(new NameArgumentParser<FileRenameCommandBuilder>());

        treeBuilder.AddCommand(treeListBuilder.Build());
        treeBuilder.AddCommand(treeGoToBuilder.Build());

        fileBuilder.AddCommand(fileShowBuilder.Build());
        fileBuilder.AddCommand(fileMoveBuilder.Build());
        fileBuilder.AddCommand(fileCopyBuilder.Build());
        fileBuilder.AddCommand(fileDeleteBuilder.Build());
        fileBuilder.AddCommand(fileRenameBuilder.Build());

        ICommandParser file = fileBuilder.Build();
        ICommandParser tree = treeBuilder.Build();
        ICommandParser connect = connectBuilder.Build();
        ICommandParser disconnect = disconnectBuilder.Build();

        connect.AddNext(disconnect);
        tree.AddNext(connect);
        file.AddNext(tree);

        var rootParser = new RootParser(file);

        return rootParser;
    }
}