using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;

public sealed class TreeListCommandBuilder : IDepthBuilder, IPrintingParamsBuilder
{
    private string? _directorySymbol;
    private string? _fileSymbol;
    private char? _indentSymbol;
    private int? _depth;

    public SetArgumentResult SetDepth(int depth)
    {
        if (_depth is not null)
        {
            return new SetArgumentResult.Failure("Depth is already set");
        }

        _depth = depth;
        return new SetArgumentResult.Success(this);
    }

    public SetArgumentResult SetDirectorySymbol(string directorySymbol)
    {
        if (_directorySymbol is not null)
        {
            return new SetArgumentResult.Failure("Directory symbol is already set");
        }

        _directorySymbol = directorySymbol;
        return new SetArgumentResult.Success(this);
    }

    public SetArgumentResult SetFileSymbol(string fileSymbol)
    {
        if (_fileSymbol is not null)
        {
            return new SetArgumentResult.Failure("File symbol is already set");
        }

        _fileSymbol = fileSymbol;
        return new SetArgumentResult.Success(this);
    }

    public SetArgumentResult SetIndentSymbol(char indentSymbol)
    {
        if (_indentSymbol is not null)
        {
            return new SetArgumentResult.Failure("Indent symbol is already set");
        }

        _indentSymbol = indentSymbol;
        return new SetArgumentResult.Success(this);
    }

    public BuildingResult Build()
    {
        _directorySymbol ??= "[D]";
        _fileSymbol ??= "[F]";
        _indentSymbol ??= ' ';

        return _depth is null
            ? new BuildingResult.Failure("Depth cannot be null")
            : new BuildingResult.Success(
                new TreeListCommand(
                    _depth.Value,
                    _directorySymbol,
                    _fileSymbol,
                    _indentSymbol.Value));
    }
}