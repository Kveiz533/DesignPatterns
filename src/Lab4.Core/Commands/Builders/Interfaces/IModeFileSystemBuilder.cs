using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

public interface IModeFileSystemBuilder : ICommandBuilder
{
    SetArgumentResult SetModeFileSystem(IFileSystem fileSystem);
}