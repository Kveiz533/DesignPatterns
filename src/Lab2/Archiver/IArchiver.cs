using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver;

public interface IArchiver
{
    void Archive(Message message);
}