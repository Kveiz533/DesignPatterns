using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

public interface ISessionState
{
    IFileSystem FileSystem { get; }

    string BasePath { get; }

    string CurrentPath { get; }

    bool TryConnect(ISession session, IFileSystem fileSystem, string basePath);

    bool TryDisconnect(ISession session);

    bool TryChangePath(string newPath);
}