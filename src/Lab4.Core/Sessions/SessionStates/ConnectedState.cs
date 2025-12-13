using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

public sealed class ConnectedState : ISessionState
{
    public IFileSystem FileSystem { get; }

    public string CurrentPath { get; private set; }

    public string BasePath { get; }

    public ConnectedState(IFileSystem fileSystem, string basePath)
    {
        FileSystem = fileSystem;
        BasePath = basePath;
        CurrentPath = basePath;
    }

    public bool TryConnect(Session session, IFileSystem fileSystem, string basePath)
    {
        return false;
    }

    public bool TryDisconnect(Session session)
    {
        session.UpdateState(new DisconnectedState());
        return true;
    }

    public bool TryChangePath(string newPath)
    {
        CurrentPath = newPath;
        return true;
    }
}