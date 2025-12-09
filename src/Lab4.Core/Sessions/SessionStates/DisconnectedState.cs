using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

public sealed class DisconnectedState : ISessionState
{
    public IFileSystem FileSystem => new DefaultFileSystem();

    public string BasePath => string.Empty;

    public string CurrentPath => string.Empty;

    public bool TryConnect(ISession session, IFileSystem fileSystem, string basePath)
    {
        session.UpdateState(new ConnectedState(fileSystem, basePath));
        return true;
    }

    public bool TryDisconnect(ISession session)
    {
        return false;
    }

    public bool TryChangePath(string newPath)
    {
        return false;
    }
}