using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeCommandBuilders;

public sealed class TreeListCommandBuilder : IDepthBuilder
{
    private int? _depth;

    public SetArgumentResult SetDepth(int depth)
    {
        if (_depth is not null)
        {
            return new SetArgumentResult.Failure("Depth is already set.");
        }

        _depth = depth;
        return new SetArgumentResult.Success(this);
    }

    public BuildingResult Build()
    {
        return _depth is null
            ? new BuildingResult.Failure("Depth cannot be null.")
            : new BuildingResult.Success(
                new TreeListCommand(
                    _depth.Value,
                    new PrintingEntities("[D]", "[F]", ' '),
                    Console.Out));
    }
}